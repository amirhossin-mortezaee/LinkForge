# 🚀 LinkForge

<p align="center">
  <strong>Modern • Fast • Scalable URL Shortener</strong>
  <br />
  Built with ASP.NET Core & Clean Architecture
</p>

---

## 🇬🇧 English

### 📌 About

**LinkForge** is a modern, fast, and scalable URL Shortener built with ASP.NET Core.

It allows users to convert long URLs into short and shareable links. Users can manage their URLs, create custom aliases, set expiration dates, and track click statistics.

The goal of this project is not simply to create a basic URL Shortener. LinkForge is designed as a portfolio-oriented backend project that demonstrates modern software development practices, clean architecture, scalable design, and production-ready concepts.

---

### ✨ Features

#### 🔗 URL Management

* Create short URLs
* Generate unique short codes
* Redirect users to the original URL
* Create custom aliases
* Set expiration dates
* Activate or deactivate URLs
* Update and delete URLs

#### 👤 User Management

* User registration
* Authentication and authorization
* JWT Authentication
* Refresh Tokens
* Users can manage their own URLs

#### 📊 Analytics

* Total click count
* Daily, weekly, and monthly statistics
* Browser information
* Device information
* Referrer information

#### ⚡ Performance

* Redis caching
* Database indexing
* Optimized URL resolution
* Cache invalidation
* Rate limiting

#### 🛡️ Security

* JWT Authentication
* Authorization
* Input validation
* URL validation
* Global exception handling

---

## 🏗️ Architecture

LinkForge follows the principles of **Clean Architecture**.

```text
UrlShortener.Domain
        ↑
UrlShortener.Application
        ↑
UrlShortener.Infrastructure
        ↑
UrlShortener.API
```

### Domain

The core layer of the application.

* Entities
* Value Objects
* Domain Interfaces
* Domain Exceptions
* Business Rules

> The Domain layer should not depend on external frameworks, databases, or infrastructure.

### Application

Contains the application's use cases.

* Commands
* Queries
* Command Handlers
* Query Handlers
* Validation
* Application Interfaces

The project uses the **CQRS pattern** to separate commands and queries.

### Infrastructure

Contains technical implementations and integrations.

* Entity Framework Core
* PostgreSQL
* Redis
* Authentication
* Repository implementations
* External services

### API

The entry point of the application.

* Controllers
* Middleware
* Authentication configuration
* Dependency Injection
* Swagger / OpenAPI
* Error handling

---

## 🛠️ Tech Stack

| Category          | Technologies                                       |
| ----------------- | -------------------------------------------------- |
| **Backend**       | .NET 9, ASP.NET Core Web API, C#                   |
| **Architecture**  | Clean Architecture, CQRS, Rich Domain Model, SOLID |
| **Database**      | PostgreSQL, Entity Framework Core                  |
| **Libraries**     | MediatR, FluentValidation, Redis                   |
| **Security**      | ASP.NET Core Identity, JWT                         |
| **Logging**       | Serilog                                            |
| **Documentation** | Swagger / OpenAPI                                  |
| **Testing**       | xUnit, FluentAssertions                            |
| **DevOps**        | Docker, Docker Compose, GitHub Actions             |

---

## 📁 Project Structure

```text
LinkForge
│
├── src
│   ├── UrlShortener.Domain
│   ├── UrlShortener.Application
│   ├── UrlShortener.Infrastructure
│   └── UrlShortener.API
│
├── tests
│
├── Dockerfile
├── docker-compose.yml
└── README.md
```

---

## 🚧 Project Status

**Status: 🟢 Active Development**

### Development Roadmap

* [x] Create Solution
* [x] Configure Clean Architecture Layers
* [x] Configure Project References
* [ ] Create Domain Entities
* [ ] Implement Short URL Creation
* [ ] Implement Short Code Generator
* [ ] Configure Database
* [ ] Implement Redirect System
* [ ] Add Authentication
* [ ] Add JWT Authentication
* [ ] Add Redis Cache
* [ ] Add Analytics
* [ ] Add Rate Limiting
* [ ] Add Logging
* [ ] Add Tests
* [ ] Add Docker Support
* [ ] Configure CI/CD

---

# 🇮🇷 فارسی

## 📌 درباره پروژه

**LinkForge** یک سرویس مدرن، سریع و مقیاس‌پذیر برای کوتاه‌سازی و مدیریت لینک‌ها است که با استفاده از **ASP.NET Core** توسعه داده می‌شود.

این پروژه به کاربران اجازه می‌دهد لینک‌های بلند خود را به لینک‌های کوتاه و قابل اشتراک‌گذاری تبدیل کنند.

کاربران می‌توانند لینک‌های خود را مدیریت کنند، برای آن‌ها نام دلخواه انتخاب کنند، تاریخ انقضا تعیین کنند و آمار بازدید لینک‌های خود را مشاهده کنند.

هدف LinkForge فقط ساخت یک URL Shortener ساده نیست. این پروژه با هدف ساخت یک **Backend حرفه‌ای و نزدیک به محیط Production** طراحی شده است تا مفاهیمی مانند Clean Architecture، CQRS، Authentication، Caching، Testing و Docker در یک پروژه واقعی پیاده‌سازی شوند.

---

## ✨ قابلیت‌های پروژه

### 🔗 مدیریت لینک‌ها

* ساخت لینک کوتاه
* تولید Short Code منحصربه‌فرد
* هدایت کاربر به لینک اصلی
* ایجاد Alias دلخواه
* تعیین تاریخ انقضا
* فعال یا غیرفعال کردن لینک
* ویرایش و حذف لینک

### 👤 مدیریت کاربران

* ثبت‌نام کاربران
* ورود و احراز هویت
* JWT Authentication
* Refresh Token
* Authorization
* مدیریت لینک‌های اختصاصی هر کاربر

### 📊 آمار و Analytics

* تعداد کل کلیک‌ها
* آمار روزانه
* آمار هفتگی
* آمار ماهانه
* اطلاعات مرورگر
* اطلاعات دستگاه
* اطلاعات Referrer

### ⚡ عملکرد

* Redis Caching
* Database Indexing
* بهینه‌سازی فرآیند Redirect
* Cache Invalidation
* Rate Limiting

### 🛡️ امنیت

* JWT Authentication
* Authorization
* Input Validation
* اعتبارسنجی URL
* Rate Limiting
* Global Exception Handling

---

## 🏗️ معماری پروژه

این پروژه بر اساس اصول **Clean Architecture** طراحی شده است.

```text
Domain
   ↑
Application
   ↑
Infrastructure
   ↑
API
```

### Domain

هسته اصلی پروژه و محل قرارگیری Business Logic است.

* Entityها
* Value Objectها
* Interfaceهای Domain
* Exceptionهای اختصاصی
* قوانین کسب‌وکار

> این لایه نباید به Database، Framework یا Infrastructure وابسته باشد.

### Application

شامل Use Caseهای پروژه است.

عملیات‌ها با استفاده از الگوی **CQRS** پیاده‌سازی می‌شوند.

* Commands
* Queries
* Handlers
* Validators

### Infrastructure

شامل پیاده‌سازی جزئیات فنی پروژه است.

* Database
* Entity Framework Core
* PostgreSQL
* Redis
* Authentication
* Repositoryها
* External Services

### API

نقطه ورود سیستم است.

* Controllers
* Middleware
* Dependency Injection
* Swagger
* Error Handling

---

## 🛠️ تکنولوژی‌های پروژه

| بخش               | تکنولوژی                                           |
| ----------------- | -------------------------------------------------- |
| **Backend**       | .NET 9, ASP.NET Core Web API, C#                   |
| **Architecture**  | Clean Architecture, CQRS, Rich Domain Model, SOLID |
| **Database**      | PostgreSQL, Entity Framework Core                  |
| **Libraries**     | MediatR, FluentValidation, Redis                   |
| **Security**      | ASP.NET Core Identity, JWT                         |
| **Logging**       | Serilog                                            |
| **Documentation** | Swagger / OpenAPI                                  |
| **Testing**       | xUnit, FluentAssertions                            |
| **DevOps**        | Docker, Docker Compose, GitHub Actions             |

---

## 🚀 هدف پروژه

هدف نهایی LinkForge ساخت یک Backend حرفه‌ای و قابل توسعه است که مهارت‌های زیر را در یک پروژه عملی نشان دهد:

* Clean Architecture
* Clean Code
* SOLID Principles
* CQRS
* Database Design
* Authentication & Authorization
* Caching
* Performance Optimization
* API Design
* Logging
* Testing
* Docker
* CI/CD

---

## 👨‍💻 Author

Developed by **Amirhossein Mortezaee**

⭐ If you like this project, consider giving it a star!
