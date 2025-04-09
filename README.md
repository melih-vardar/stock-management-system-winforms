# Stok Yönetim Sistemi

Bu uygulama, işletmelerin ürün envanterini, stok hareketlerini ve satın alma siparişlerini yönetmelerine yardımcı olan basit bir stok yönetim sistemidir.

## Özellikler

- Ürün yönetimi (ekleme, düzenleme, silme)
- Stok takibi
- Düşük stok uyarıları
- Stok giriş/çıkış işlemleri
- Satın alma siparişi oluşturma
- Satın alma siparişi onaylama

## Gereksinimler

- .NET 8.0 SDK
- MySQL veritabanı
- Docker ve Docker Compose (opsiyonel)

## Kurulum

Bu proje farklı bilgisayarlarda kolayca çalıştırılabilmesi için Docker Compose yapılandırmasına sahiptir:

1. Docker ve Docker Compose'un yüklü olduğundan emin olun.
2. Projeyi klonlayın veya indirin.
3. Proje dizininde terminali açın ve şu komutu çalıştırın:
   ```
   docker-compose up -d
   ```
4. MySQL veritabanı 3306 portunda çalışmaya başlayacaktır.
5. Uygulamayı çalıştırın. Veritabanı bağlantısı otomatik olarak yapılandırılmıştır.

## Veritabanı Yapılandırması

Varsayılan veritabanı bağlantı dizesi:
```
server=localhost;user=stockuser;password=stockpass;database=stockmanagement;allowPublicKeyRetrieval=true;sslMode=none
```

Bağlantı dizesini değiştirmek istiyorsanız, `Models/DbContextFactory.cs` dosyasını düzenleyin.

## DBeaver ile Veritabanına Bağlanma

1. DBeaver'ı açın
2. Database > New Database Connection menüsünü seçin
3. MySQL'i seçin ve "Next" tıklayın
4. Bağlantı ayarlarını girin:
   - Host: localhost
   - Port: 3306
   - Database: stockmanagement
   - Username: stockuser  
   - Password: stockpass
5. "Driver properties" sekmesine geçin ve ekleyin:
   - allowPublicKeyRetrieval = true
   - useSSL = false
6. "Test Connection" butonuna tıklayın
7. Bağlantı başarılı ise "Finish" ile tamamlayın

