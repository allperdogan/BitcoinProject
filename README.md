# Bitcoin Değer Takip Uygulaması

Bu proje, bir arka plan servisi kullanarak rastgele bir kaynaktan Bitcoin değerlerini alabilen bir uygulama geliştirmeyi amaçlamaktadır. Uygulama, verileri bir grafik olarak temsil edebilen bir ön uç içermeli ve bu verileri gün, hafta ve ay sırasına koyabilme yeteneğine sahip olmalıdır.

## İçindekiler
- [Teknik Tasarım](#teknik-tasarım)
  - [Veritabanı Yapısı](#veritabanı-yapısı)
  - [Arka Plan Servisi](#arka-plan-servisi)
  - [Ön Uç](#ön-uç)
  - [Giriş Yapılandırması](#giriş-yapılandırması)
- [Bağımlılıklar](#bağımlılıklar)
- [Kullanım](#kullanım)
- [Docker Entegrasyonu](#docker-entegrasyonu)

## Teknik Tasarım

### Veritabanı Yapısı

Uygulama PostgreSQL veritabanını kullanır. Veritabanı yapısı, Bitcoin değerlerini depolamak için gerekli alanları içerecek şekilde tasarlanmıştır. Veritabanı ile etkileşimde bulunmak için Entity Framework PostgreSQL paketi kullanılmaktadır.

### Arka Plan Servisi

Belirli aralıklarla Bitcoin değerlerinde güncellemeleri kontrol etmek üzere bir arka plan servisi uygulanmıştır. Bu, uygulamanın her zaman güncel bilgileri sunmasını sağlar.

### Ön Uç

Ön uç, [Angular/HTML/CSS] kullanılarak geliştirilmiştir. Bitcoin değerlerini bir grafik olarak temsil etmek ve kullanıcılara gün, hafta ve ay sırasına koyma imkanı sağlar.

### Giriş Yapılandırması

Uygulama, .NET çözümlerine dayalı bir giriş yapısı içerir. Yalnızca giriş yapan kullanıcılar, grafik verilerine erişebilir, bu da bilgilerin güvenliğini ve gizliliğini sağlar.

## Bağımlılıklar

- [PostgreSQL](https://www.postgresql.org/)
- [Entity Framework Core](https://docs.microsoft.com/en-us/ef/core/)
- [Angular]
- [.NET](https://dotnet.microsoft.com/)
- [Docker](https://www.docker.com/)
- [Docker Compose](https://docs.docker.com/compose/)

## Kullanım

1. Depoyu klonlayın.
2. PostgreSQL veritabanını kurun ve bağlantı dizesini arka planda yapılandırın.
3. Arka plan servisini çalıştırın.
4. Ön uç uygulamasını kurun ve çalıştırın.
5. Uygulamaya belirtilen URL üzerinden erişin.

## Docker Entegrasyonu

Proje, dağıtım ve ölçeklenebilirlik için Dockerize edilmeyi hedefler. Şu anda Docker kurulumu devam etmektedir. Plan, Docker Compose kullanarak arka plan servisini, ön uçu ve arka uçu Dockerize etmektir. Docker Compose çalıştırıldığında PostgreSQL tablo yapısı oluşturulur ve yeniden başlatma sonrasında bütünlüğünü ve verilerini korur.
