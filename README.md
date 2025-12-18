# TaskManager – Teste Técnico

## 📌 Visão Geral

Projeto desenvolvido como **teste técnico**, com foco em boas práticas de arquitetura, separação de responsabilidades e regras de negócio bem definidas.

O sistema permite o **cadastro e listagem de tarefas**, cada uma com um **SLA definido em horas**, além de upload opcional de arquivo.

---

## 🧱 Arquitetura

O projeto segue uma organização inspirada em **Clean Architecture**:

```
TaskManager
│
├── TaskManager.Api            # Camada de apresentação (API REST)
├── TaskManager.Application    # Casos de uso e interfaces
├── TaskManager.Domain         # Entidades e regras de negócio
├── TaskManager.Infrastructure # Persistência e implementações
```

### Responsabilidades

* **Domain**: entidades, enums e validações de regra de negócio
* **Application**: casos de uso (handlers) e contratos
* **Infrastructure**: repositórios, banco (InMemory) e serviços
* **API**: controllers, configuração e endpoints

---

## ⚙️ Tecnologias Utilizadas

* **.NET 8**
* **ASP.NET Core Web API**
* **Entity Framework Core (InMemory)**
* **Swagger (OpenAPI)**
* **HTML / CSS / JavaScript (Frontend simples)**

---

## 🚀 Como Executar o Projeto

### Pré-requisitos

* .NET SDK 8+

### Passos

```bash
dotnet restore
dotnet run --project TaskManager.Api
```

### Acessos

* API: [http://localhost:5000](http://localhost:5000)
* Swagger: [http://localhost:5000/swagger](http://localhost:5000/swagger)

---

## 📡 Endpoints Principais

### Criar tarefa

`POST /api/tasks`

**Parâmetros (multipart/form-data):**

* `title` (string)
* `slaInHours` (int)
* `file` (opcional)

### Listar tarefas

`GET /api/tasks`

---

## ⏱️ SLA

* O SLA é informado em **horas** no cadastro
* Internamente, o sistema calcula o tempo restante
* Caso o SLA seja inválido (≤ 0), a API retorna **400 Bad Request**

---

## 🖥️ Frontend

* Frontend simples integrado à API
* Permite:

  * Criar tarefas
  * Listar tarefas
  * Visualizar status e SLA restante

---

## ✅ Boas Práticas Aplicadas

* Separação clara de camadas
* Regra de negócio protegida no domínio
* Validações no backend e frontend
* Tratamento de erros com respostas HTTP adequadas

---

## 📄 Observações Finais

Este projeto foi desenvolvido com foco em clareza, organização e facilidade de evolução, priorizando decisões arquiteturais coerentes com aplicações reais.

---

👤 **Autor**
Matheus Teixeira
