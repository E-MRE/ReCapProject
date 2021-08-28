using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    public class Messages
    {
        //**********************************   CAR    *********************************//
        public const string CarNameInvalid = "Araba ismi en az 2 karakter olmalıdır.";
        public const string DailyPriceInvalid = "Günlük fiyat 0'dan büyük olmalıdır.";

        public const string CarAdded = "Araba eklendi";
        public const string CarUpdated = "Araba güncellendi";
        public const string CarDeleted = "Araba silindi";

        public const string CarsListed = "Arabalar listelendi";
        public const string CarsListedByBrand = "Seçilen markaya göre arabalar listelendi";
        public const string CarsListedByColor = "Seçilen renge göre arabalar listelendi";
        public const string CarDetailsListed = "Araba detayları listelendi";
        public const string GetCar = "Araba getirildi";

        //**********************************  BRAND   *********************************//
        public const string BrandAdded = "Marka eklendi";
        public const string BrandUpdated = "Marka güncellendi";
        public const string BrandDeleted = "Marka silindi";
        public const string GetBrand = "Marka getirildi";
        public const string BrandssListed = "Markalar listelendi";

        //**********************************  COLOR   *********************************//
        public const string ColorAdded = "Renk eklendi";
        public const string ColorUpdated = "Renk güncellendi";
        public const string ColorDeleted = "Renk silindi";
        public const string GetColor = "Renk getirildi";
        public const string ColorsListed = "Renkler listelendi";

        //**********************************  USER   *********************************//
        public const string UserAdded = "Kullanıcı eklendi";
        public const string UserUpdated = "Kullanıcı güncellendi";
        public const string UserDeleted = "Kullanıcı silindi";
        public const string GetUser = "Kullanıcı getirildi";
        public const string UsersListed = "Kullanıcılar listelendi";

        //********************************  CUSTOMER  ********************************//
        public const string CustomerAdded = "Müşteri eklendi";
        public const string CustomerUpdated = "Müşteri güncellendi";
        public const string CustomerDeleted = "Müşteri silindi";
        public const string GetCustomer = "Müşteri getirildi";
        public const string CustomersListed = "Müşteriler listelendi";

        //**********************************  RENTAL   *********************************//
        public const string RentalCarNotDelivered = "Kiralanacak araba teslim edilmemiş";
        public const string RentalAdded = "Kiralama eklendi";
        public const string RentalUpdated = "Kiralama güncellendi";
        public const string RentalDeleted = "Kiralama silindi";
        public const string GetRental = "Kiralama getirildi";
        public const string RentalsListed = "Kiralamalar listelendi";

        //**********************************  CAR IMAGE   *********************************//
        public const string CarImageLimitExceded = "Araba resim sınırı aşıldı";
        public const string CarImageNotFound = "Araba resmi bulunamadı";

        //**********************************  GENRAL   *********************************//
        public const string AddedSuccess = "Başarıyla eklendi";
        public const string UpdatedSuccess = "Başarıyla güncellendi";
        public const string DeletedSuccess = "Başarıyla silindi";
        public const string GetItem = "Nesne getirildi";
        public const string ItemsListed = "Nesneler listelendi";
    }
}
