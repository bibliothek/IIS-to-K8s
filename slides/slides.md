---
marp: true
---

<!-- theme: uncover -->

# IIS to K8s

---

![width:800px](https://pbs.twimg.com/media/EDrZEKCWwAAG_Ty?format=jpg&name=large)

---

## Docker

* an image format
* a runtime
* a dev tool

---

## Sample app

`git clone https://github.com/bibliothek/IIS-to-K8s.git`

`git checkout tags/v0.1`

<!-- 

Visual Studio -> Project -> Add -> Docker Support

docker build . -t rankingsapp

docker run -it --rm -p 8080:80 -e ConnectionStrings__RankingsContext="Server=host.docker.internal\SQLEXPRESS;Database=Rankings;User Id=testuser;Password=martin123!;MultipleActiveResultSets=true" rankingsapp

-->

---

## Kubernetes

* Container orchestrator
* distributed database
* desired state configuration
* API server

---

### Kubernetes components

![width:1000px](https://d33wubrfki0l68.cloudfront.net/2475489eaf20163ec0f54ddc1d92aa8d4c87c96b/e7c81/images/docs/components-of-kubernetes.svg)

[Kubernetes Components Overview](https://kubernetes.io/docs/concepts/overview/components/)

---

### Kubernetes resources

* Pod
* Deployment
* Service
* Ingress
* Persistent Volume Claim
* Job
* Secrets
* ConfigMaps
* StatefulSet
* ...

---

### Kubernetes demo

<!-- 

kubectl get all

kubectl create deployment mynginx --image=nginx

kubectl delete deployment mynginx

kubectl create deployment rankings --image=rankingsapp:latest --dry-run=client -o yaml > deployment.yaml

kubectl apply -f .\deployment.yaml

kubectl port-forward pod/rankings-??? 8080:80

kubectl delete -f .\deployment.yaml

-->

---

## Helm

* Client for managing K8s applications
    + helm search
    + helm install
    + helm upgrade
* Package format for K8s resources
* Templating engine for K8s resources
* Repository for charts
    + https://charts.bitnami.com/bitnami
    + ...

---

### Helm demo

<!-- 

helm create rankings

helm install rankings-instance rankings

kubectl create service clusterip rankings --tcp=80:80 --dry-run -o yaml

helm upgrade rankings-instance .\rankings\

helm repo list

helm repo add ingress-nginx https://kubernetes.github.io/ingress-nginx

helm search repo ingress

helm install myingress ingress-nginx/ingress-nginx

-->

---

## Storage

+ PersistentVolume
+ PersistentVolumeClaim
+ StorageClass

---

## Lens

![width:700px](https://k8slens.dev/images/header-lens.png)

https://k8slens.dev/