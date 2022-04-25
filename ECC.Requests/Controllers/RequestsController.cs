using ECC.Requests.Contracts;
using ECC.Requests.Database;
using ECC.Requests.Models.CallRequestModels;
using ECC.Requests.Models.EmergencyCodeModels;
using ECC.Shared.Requests.Contracts;
using ECC.Shared.Requests.Contracts.CallRequestDtos;
using ECC.Shared.Requests.Contracts.EmergencyCodeRequestDtos;
using ECC.Shared.Requests.Contracts.SharedRequests;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace ECC.Requests.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestsController : ControllerBase
    {
        private readonly DataContext _ctx;

        public RequestsController(DataContext ctx)
        {
            _ctx = ctx;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetRequestDto>>> Get()
        {
            return Ok(await _ctx.Requests
                .Select(x => x.AsDto())
                .ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<object>> Get(int id)
        {
            var request = await _ctx.Requests.FirstOrDefaultAsync(x => x.Id == id);

            if (request == null) return NotFound();

            switch (request.RequestType)
            {
                case RequestType.CallRequest:
                    return Ok(GetRequest<CallRequestModel>(id));
                case RequestType.EmergencyCode:
                    return Ok(GetRequest<EmergencyCodeRequest>(id));
                case RequestType.UM:
                    break;
                case RequestType.SystemFailure:
                    break;
                default:
                    break;
            }

            return NotFound();
        }

        // TODO: move to seperate class
        private T GetRequest<T>(int id) where T : class
            => id == 0 ? null : _ctx.Set<T>().Find(id);



        [HttpPost]
        public async Task<ActionResult> CreateRequest([FromBody] object payload)
        {
            if (payload != null)
            {
                var createRequestDto = JsonConvert.DeserializeObject<CreateRequestDto>(payload.ToString());
                switch (createRequestDto.RequestType)
                {
                    case RequestType.CallRequest:
                        var callRequest = JsonConvert.DeserializeObject<CreateCallRequestDto>(payload.ToString());
                        var getCallRequestDto = await AddToDb(callRequest);
                        return Ok(getCallRequestDto);
                    case RequestType.EmergencyCode:
                        var emergencyCode = JsonConvert.DeserializeObject<CreateEmergencyCodeRequestDto>(payload.ToString());
                        var getEmergencyCodeRequestDto = await AddToDb(emergencyCode);
                        return Ok(getEmergencyCodeRequestDto);
                    case RequestType.UM:
                        break;
                    case RequestType.SystemFailure:
                        break;
                    default:
                        break;
                }
            }
            return BadRequest("request is unknown");
        }

        // TODO: move to seperate class
        private async Task<object> AddToDb<T>(T obj)
        {
            if (obj is CreateCallRequestDto)
            {
                CreateCallRequestDto createCallRequestDto = obj as CreateCallRequestDto;
                var callRequestModel = createCallRequestDto.AsModel();
                _ctx.CallRequests.Add(callRequestModel);
                await _ctx.SaveChangesAsync();

                await AddOrRemoveAssociatedMedicalHistories(callRequestModel.Id, createCallRequestDto.MedicalHistoryIds);

                var getCallRequestDto = await _ctx.CallRequests
                    .Where(x => x.Id == callRequestModel.Id)
                    .Include(x => x.CallRequestMedicalHistories)
                        .ThenInclude(x => x.MedicalHistory)
                    .Select(x => x.AsDto())
                    .FirstOrDefaultAsync();

                return getCallRequestDto;
            }
            else if (obj is CreateEmergencyCodeRequestDto)
            {
                CreateEmergencyCodeRequestDto emergencyCodeRequestDto = obj as CreateEmergencyCodeRequestDto;
                var emergencyCodeRequest = emergencyCodeRequestDto.AsModel();
                _ctx.EmergencyCodeRequests.Add(emergencyCodeRequest);
                await _ctx.SaveChangesAsync();

                var getEmergencyCodeRequestDto = await _ctx.EmergencyCodeRequests
                    .Where(x => x.Id == emergencyCodeRequest.Id)
                    .Include(x => x.Code)
                    .Select(x => x.AsDto())
                    .FirstOrDefaultAsync();

                return getEmergencyCodeRequestDto;
            }

            return null;

        }

        // TODO: move to seperate class
        private async Task AddOrRemoveAssociatedMedicalHistories(int callRequestId, int[] medicalHistoryIds)
        {
            var medicalHistoriesToBeDeleted = _ctx.CallRequestMedicalHistories
                .Where(x => x.CallRequestId == callRequestId);

            _ctx.CallRequestMedicalHistories.RemoveRange(medicalHistoriesToBeDeleted);

            if (medicalHistoryIds.Length > 0)
            {
                List<CallRequestMedicalHistory> callRequestMedicalHistoriesToBeAdded = new List<CallRequestMedicalHistory>();

                foreach (var medicalHistoryId in medicalHistoryIds)
                {
                    callRequestMedicalHistoriesToBeAdded.Add(new CallRequestMedicalHistory
                    {
                        CallRequestId = callRequestId,
                        MedicalHistoryId = medicalHistoryId,
                    });
                }

                _ctx.CallRequestMedicalHistories.AddRange(callRequestMedicalHistoriesToBeAdded);
            }

            await _ctx.SaveChangesAsync();
        }
    
    }
}
