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

---

## Kubernetes

* Container orchestrator
* distributed database
* desired state configuration
* API server

---

### Kubernetes components

![width:1100px](https://d33wubrfki0l68.cloudfront.net/2475489eaf20163ec0f54ddc1d92aa8d4c87c96b/e7c81/images/docs/components-of-kubernetes.svg)

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

## Lens

![width:800px](https://k8slens.dev/images/header-lens.png)
