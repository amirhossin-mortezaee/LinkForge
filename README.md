\# 🚀 LinkForge



<p align="center">

&#x20; <strong>A Modern, Fast and Scalable URL Shortener</strong>

</p>



<p align="center">

&#x20; Built with ASP.NET Core and Clean Architecture

</p>



\---



\# 🇬🇧 English



\## 📌 About The Project



\*\*LinkForge\*\* is a modern, fast, and scalable URL Shortener built with ASP.NET Core.



The project allows users to convert long URLs into short and shareable links. Users will be able to manage their links, create custom aliases, set expiration dates, and track click statistics.



The main goal of LinkForge is not simply to create a basic URL Shortener. This project is designed as a portfolio-oriented backend application that demonstrates modern software development practices, clean architecture, scalable design, and production-ready concepts.



\---



\## ✨ Features



\### 🔗 URL Management



\* Create short URLs

\* Generate unique short codes

\* Redirect users to the original URL

\* Create custom aliases

\* Set expiration dates

\* Activate or deactivate URLs

\* Update URLs

\* Delete URLs



\### 👤 User Management



\* User registration

\* Authentication

\* JWT Authentication

\* Refresh Tokens

\* Authorization

\* Users can manage their own URLs



\### 📊 Analytics



\* Total click count

\* Daily click statistics

\* Weekly statistics

\* Monthly statistics

\* Browser information

\* Device information

\* Referrer information



\### ⚡ Performance



\* Redis caching

\* Database indexing

\* Optimized URL resolution

\* Cache invalidation

\* Rate limiting



\### 🛡️ Security



\* JWT Authentication

\* Authorization

\* Input validation

\* URL validation

\* Rate limiting

\* Global exception handling



\---



\# 🏗️ Architecture



The project follows the principles of \*\*Clean Architecture\*\*.



```text

UrlShortener.Domain

&#x20;       ↑

UrlShortener.Application

&#x20;       ↑

UrlShortener.Infrastructure

&#x20;       ↑

UrlShortener.API

```



\## Domain



The core layer of the application.



Responsibilities:



\* Entities

\* Value Objects

\* Domain Interfaces

\* Domain Exceptions

\* Business Rules



The Domain layer should not depend on external frameworks, databases, or infrastructure.



\---



\## Application



Contains the application's use cases.



Responsibilities:



\* Commands

\* Queries

\* Command Handlers

\* Query Handlers

\* Validation

\* Application Interfaces



The project uses the \*\*CQRS pattern\*\* for separating commands and queries.



\---



\## Infrastructure



Contains implementations related to external services and technical concerns.



Responsibilities:



\* Database

\* Entity Framework Core

\* PostgreSQL

\* Redis

\* Authentication

\* Repository Implementations

\* External Services



\---



\## API



The entry point of the application.



Responsibilities:



\* Controllers

\* Middleware

\* Authentication Configuration

\* Dependency Injection

\* Swagger Documentation

\* Error Handling



\---



\# 🛠️ Tech Stack



\### Backend



\* .NET 9

\* ASP.NET Core Web API

\* C#



\### Architecture



\* Clean Architecture

\* CQRS

\* Rich Domain Model

\* SOLID Principles



\### Database



\* PostgreSQL

\* Entity Framework Core



\### Tools \& Libraries



\* MediatR

\* FluentValidation

\* Redis

\* ASP.NET Core Identity

\* JWT Authentication

\* Serilog

\* Swagger / OpenAPI



\### Testing



\* xUnit

\* FluentAssertions



\### DevOps



\* Docker

\* Docker Compose

\* GitHub Actions



\---



\# 📁 Project Structure



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



\---



\# 🚧 Project Status



The project is currently under active development.



\## Development Roadmap



\* \[x] Create Solution

\* \[x] Configure Clean Architecture Layers

\* \[x] Configure Project References

\* \[ ] Create Domain Entities

\* \[ ] Implement Short URL Creation

\* \[ ] Implement Short Code Generator

\* \[ ] Configure Database

\* \[ ] Implement Redirect System

\* \[ ] Add Authentication

\* \[ ] Add JWT Authentication

\* \[ ] Add Redis Cache

\* \[ ] Add Analytics

\* \[ ] Add Rate Limiting

\* \[ ] Add Logging

\* \[ ] Add Tests

\* \[ ] Add Docker Support

\* \[ ] Configure CI/CD



\---



\# 🇮🇷 فارسی



\## 📌 درباره پروژه



\*\*LinkForge\*\* یک سرویس مدرن، سریع و مقیاس‌پذیر برای کوتاه‌سازی و مدیریت لینک‌ها است که با استفاده از ASP.NET Core توسعه داده می‌شود.



این پروژه به کاربران اجازه می‌دهد لینک‌های بلند خود را به لینک‌های کوتاه و قابل اشتراک‌گذاری تبدیل کنند.



کاربران می‌توانند لینک‌های خود را مدیریت کنند، برای لینک Alias دلخواه انتخاب کنند، تاریخ انقضا تعیین کنند و آمار بازدید لینک‌های خود را مشاهده کنند.



هدف LinkForge فقط ساخت یک URL Shortener ساده نیست.



هدف اصلی این پروژه، ساخت یک Backend حرفه‌ای و نزدیک به محیط Production است که مفاهیمی مانند معماری تمیز، CQRS، Authentication، Caching، Testing و Docker را در یک پروژه واقعی پیاده‌سازی می‌کند.



\---



\## ✨ قابلیت‌های پروژه



\### 🔗 مدیریت لینک‌ها



\* ساخت لینک کوتاه

\* تولید Short Code منحصربه‌فرد

\* Redirect به لینک اصلی

\* ایجاد Alias دلخواه

\* تعیین تاریخ انقضا

\* فعال یا غیرفعال کردن لینک

\* ویرایش لینک

\* حذف لینک



\### 👤 مدیریت کاربران



\* ثبت‌نام

\* ورود به سیستم

\* JWT Authentication

\* Refresh Token

\* Authorization

\* مدیریت لینک‌های اختصاصی هر کاربر



\### 📊 آمار و Analytics



\* تعداد کل کلیک‌ها

\* تعداد کلیک‌های روزانه

\* آمار هفتگی

\* آمار ماهانه

\* اطلاعات مرورگر

\* اطلاعات دستگاه

\* اطلاعات Referrer



\### ⚡ عملکرد



\* Redis Caching

\* Database Indexing

\* بهینه‌سازی فرآیند Redirect

\* Cache Invalidation

\* Rate Limiting



\### 🛡️ امنیت



\* JWT Authentication

\* Authorization

\* Validation

\* اعتبارسنجی لینک‌ها

\* Rate Limiting

\* Global Exception Handling



\---



\# 🏗️ معماری پروژه



این پروژه بر اساس اصول \*\*Clean Architecture\*\* طراحی شده است.



```text

Domain

&#x20;  ↑

Application

&#x20;  ↑

Infrastructure

&#x20;  ↑

API

```



\### Domain



هسته اصلی پروژه و محل قرارگیری Business Logic است.



شامل:



\* Entityها

\* Value Objectها

\* Interfaceهای Domain

\* Exceptionهای اختصاصی

\* قوانین کسب‌وکار



این لایه نباید به Database، Framework یا Infrastructure وابسته باشد.



\---



\### Application



شامل Use Caseهای پروژه است.



عملیات‌ها با استفاده از الگوی \*\*CQRS\*\* پیاده‌سازی می‌شوند.



شامل:



\* Commands

\* Queries

\* Handlers

\* Validators



\---



\### Infrastructure



شامل پیاده‌سازی جزئیات فنی پروژه است.



مانند:



\* Database

\* Entity Framework Core

\* PostgreSQL

\* Redis

\* Authentication

\* Repositoryها

\* External Services



\---



\### API



نقطه ورود سیستم است و شامل:



\* Controllers

\* Middleware

\* Dependency Injection

\* Swagger

\* Error Handling



می‌شود.



\---



\# 🚀 هدف پروژه



هدف نهایی LinkForge ساخت یک Backend حرفه‌ای و قابل توسعه است که مهارت‌های زیر را در یک پروژه عملی نشان دهد:



\* Clean Architecture

\* Clean Code

\* SOLID Principles

\* CQRS

\* Database Design

\* Authentication

\* Authorization

\* Caching

\* Performance Optimization

\* API Design

\* Logging

\* Testing

\* Docker

\* CI/CD



\---



\# 👨‍💻 Author



Developed by \*\*Amirhossein Mortezaee\*\*



\---



⭐ If you like this project, consider giving it a star!



