down:
	kubectl delete ns ecc
up:
	kubectl create ns ecc
	kubectl apply -f local-pvc.yaml -n ecc
	kubectl create secret generic mssql --from-literal=SA_PASSWORD="P@ssw0rd" -n ecc
	kubectl apply -f sqlusers-depl.yaml -n ecc
	kubectl apply -f users-depl.yaml -n ecc
	kubectl apply -f users-np.yaml -n ecc
	