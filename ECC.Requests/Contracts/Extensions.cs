using ECC.Requests.Models.CallRequestModels;
using ECC.Requests.Models.EmergencyCodeModels;
using ECC.Shared.Requests.Contracts;
using ECC.Shared.Requests.Contracts.CallRequestDtos;
using ECC.Shared.Requests.Contracts.EmergencyCodeRequestDtos;
using ECC.Shared.Requests.Contracts.SharedRequests;

namespace ECC.Requests.Contracts
{
    public static class Extensions
    {

        public static GetRequestDto AsDto(this Request request)
        {
            return new GetRequestDto
            {
                CreatedBy = request.CreatedBy,
                Description = request.Description,
                Id = request.Id,
                RequestType = request.RequestType,
                Title = request.Title,
            };
        }


        public static CallRequestModel AsModel(this CreateCallRequestDto callRequestDto)
        {
            return new CallRequestModel
            {
                Title = callRequestDto.Title,
                Description = callRequestDto.Description,
                CreatedAt = DateTime.Now.ToLocalTime(),
                PatientMRN = callRequestDto.PatientMRN,
                PatientName = callRequestDto.PatientName,
                PatientAge = callRequestDto.PatientAge,
                OnSet = callRequestDto.OnSet,
                RequestType = RequestType.CallRequest,
            };
        }

        public static GetCallRequestDto AsDto(this CallRequestModel callRequestModel)
        {
            return new GetCallRequestDto
            {
                Title = callRequestModel.Title,
                CreatedAt = callRequestModel.CreatedAt,
                PatientMRN = callRequestModel.PatientMRN,
                CreatedBy = callRequestModel.CreatedBy,
                Description = callRequestModel.Description,
                OnSet = callRequestModel.OnSet,
                PatientAge = callRequestModel.PatientAge,
                PatientName = callRequestModel.PatientName,
                Id = callRequestModel.Id,
                RequestType = RequestType.CallRequest,
                MedicalHistories = callRequestModel.CallRequestMedicalHistories.Select(x => new MedicalHistoryDto
                {
                    Id = x.MedicalHistoryId,
                    Name = x.MedicalHistory.Name
                })
                .ToList()
            };
        }

        public static EmergencyCodeRequest AsModel(this CreateEmergencyCodeRequestDto emergencyCodeRequestDto)
        {
            return new EmergencyCodeRequest
            {
                Title = emergencyCodeRequestDto.Title,
                Description = emergencyCodeRequestDto.Description,
                CreatedAt = DateTime.Now.ToLocalTime(),
                RequestType = RequestType.EmergencyCode,
                ActivatedAt = DateTime.Parse(emergencyCodeRequestDto.ActivatedAt),
                CodeId = emergencyCodeRequestDto.CodeId,
                ReporterName = emergencyCodeRequestDto.ReporterName,
                ReporterExtension = emergencyCodeRequestDto.ReporterExtension,
                Phase = CodePhase.One,
                Location = emergencyCodeRequestDto.Location,
            };
        }

        public static GetEmergencyCodeRequestDto AsDto(this EmergencyCodeRequest emergencyCodeRequest)
        {
            return new GetEmergencyCodeRequestDto
            {
                Id = emergencyCodeRequest.Id,
                Title = emergencyCodeRequest.Title,
                Description = emergencyCodeRequest.Description,
                ActivatedAt = emergencyCodeRequest.ActivatedAt,
                ClearedAt = emergencyCodeRequest.ClearedAt,
                CodeHasClear = emergencyCodeRequest.Code.HasClear,
                CodeHasPhases = emergencyCodeRequest.Code.HasPhases,
                CodeId = emergencyCodeRequest.CodeId,
                CodeName = emergencyCodeRequest.Code.Name,
                CreatedAt = emergencyCodeRequest.CreatedAt,
                CreatedBy = emergencyCodeRequest.CreatedBy,
                Location = emergencyCodeRequest.Location,
                Phase = emergencyCodeRequest.Phase,
                ReporterExtension = emergencyCodeRequest.ReporterExtension,
                ReporterName = emergencyCodeRequest.ReporterName,
                RequestType = RequestType.EmergencyCode,
            };
        }
    }
}
