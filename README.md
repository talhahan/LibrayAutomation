# 📚 Kütüphane Otomasyon Sistemi

## 👋 Giriş ve Genel Bakış

Merhaba!

Bu proje, bir kütüphanenin günlük yönetimini kolaylaştırmak için tasarlanmış, **kullanımı kolay bir masaüstü otomasyon** sistemidir. Uygulama sayesinde kitap envanterini, üye kayıtlarını ve en önemlisi **ödünç verme/iade alma** işlemlerini hızlı ve hatasız bir şekilde takip edebilirsiniz.

Uygulama, güvenilirliği ve performansı için **C#** dili ve **Windows Forms (WinForms)** arayüzü ile geliştirilmiştir.

---

## ✨ Temel Özellikler (Uygulama Modülleri)

Uygulamamız, kütüphane personelinin ihtiyaç duyduğu tüm temel modülleri içerir.

| Modül | Amacı | İlgili Ana Ekranlar |
| :--- | :--- | :--- |
| **Giriş ve Güvenlik** | Yetkili personelin güvenli bir şekilde sisteme giriş yapmasını sağlar. | `GirisEkranı` |
| **Kitap Yönetimi** | Kütüphanenizdeki kitapların envanterini (stok, yazar, yayın evi) tutar. Yeni kitap ekler ve mevcut kitapları günceller. | `kitapeklefrm`, `kitapListeleme` |
| **Üye Yönetimi** | Kütüphane üyelerinin kayıtlarını tutar (T.C. No, İletişim, Adres). Üye bilgilerini düzenler. | `Üye Ekleme`, `ÜyeListeleme` |
| **Ödünç & İade** | Kitapları üyelere verir ve iade alındığında kaydı kapatır. Gecikmeleri takip etmede kritiktir. | `KitapVermeİslemi`, `EmanetKitapİade` |
| **Emanet Takibi** | Halihazırda ödünçte olan kitapları listeler ve iade tarihine göre takip imkanı sunar. | `EmanetKitapListele` |
| **Raporlama ve Sıralama** | Tüm listeleri (Kitap, Üye, Ödünç) istenilen kriterlere göre düzenler ve detaylı arama yapar. | `Sıralama` |

---

## 🛠️ Teknik Bilgiler

Bu projenin temelini oluşturan teknolojiler:

* **Programlama Dili:** C#
* **Arayüz:** Windows Forms (WinForms)
* **Veritabanı:** SQL Server LocalDB / Express (Veritabanı dosyası proje klasöründe yer alır: `KütüphaneOtomasyonu.mdf`)
* **Dağıtım:** Visual Studio Kurulum Projesi (Kurulum dosyaları `Setup1453` klasöründe mevcuttur.)

---

## 🚀 Projeyi Çalıştırma (Geliştirme Ortamı)

Projeyi kendi bilgisayarınızda çalıştırmak ve incelemek için:

### 1. Ön Koşullar

* **Visual Studio**
* **SQL Server LocalDB / Express**

### 2. Adımlar

1.  **Depoyu Klonlayın:**
    ```bash
    git clone [https://github.com/talha-eren/Library_Automation.git](https://github.com/talha-eren/Library_Automation.git)
    ```
2.  **Çözümü Açın:** Ana çözüm dosyası olan **`KütüphaneOtomasyonu.sln`** dosyasını Visual Studio ile açın.
3.  **Veritabanı Kontrolü:** Proje klasörü içindeki **`KütüphaneOtomasyonu.mdf`** dosyasının doğru şekilde bağlandığından emin olun.
4.  **Başlatın:** Projeyi derleyin ve çalıştırmak için **F5** tuşuna basın.


---

## 🤝 Katkıda Bulunma

Proje hala geliştirmeye açıktır. Eğer bir hata bulur veya yeni bir özellik eklemek isterseniz, lütfen bir **Pull Request** açarak katkıda bulunun!

**Geliştirici:** Talha Eren - [GitHub Profiliniz](https://github.com/talha-eren)
