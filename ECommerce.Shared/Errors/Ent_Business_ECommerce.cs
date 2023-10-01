using ECommerce.Shared.Exceptions.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Shared.Errors
{
    public class Ent_Business_ECommerce
    {
        public static readonly Error EmailRequired = new Error { Code = "EmailRequired", Message = "E-Mail boş geçilemez." };
        public static readonly Error NameRequired = new Error { Code = "NameRequired", Message = "Ad boş geçilemez." };
        public static readonly Error SurnamelRequired = new Error { Code = "SurnamelRequired", Message = "Soyad boş geçilemez." };
        public static readonly Error CityNameRequired = new Error { Code = "CityNameRequired", Message = "Şehir boş geçilemez." };
        public static readonly Error PasswordRequired = new Error { Code = "PasswordRequired", Message = "Şifre boş geçilemez." };
        public static readonly Error RePasswordRequired = new Error { Code = "RePasswordRequired", Message = "Şifre tekrarı boş geçilemez." };
        public static readonly Error PasswordNotEqual = new Error { Code = "PasswordNotEqual", Message = "Şifre ve şifre tekrar uyuşmamaktadır." };
        public static readonly Error WrongEmail = new Error { Code = "WrongEmail", Message = "E-Mail hatalıdır." };
        public static readonly Error WrongPassword = new Error { Code = "WrongPassword", Message = "Şifre en az 10 karakter olmalı ve bir büyük harf ile en az 1rakam içermelidir." };
        public static readonly Error EmailExist = new Error { Code = "EmailExist", Message = "E-Mail mevcuttur." };
        public static readonly Error UserNotActive = new Error { Code = "UserNotActive", Message = "Kullanıcı aktif değildir." };
        public static readonly Error PasswordNotAcceptable = new Error { Code = "PasswordNotAcceptable", Message = "Şifre yanlıştır." };
        public static readonly Error CategoryRequired = new Error { Code = "CategoryRequired", Message = "Kategori adı boş geçilemez." };
        public static readonly Error CategoryExist = new Error { Code = "CategoryExist", Message = "Kategori mevcuttur." };
        public static readonly Error AmountRequired = new Error { Code = "AmountRequired", Message = "Tutar boş geçilemez." };
        public static readonly Error StockRequired = new Error { Code = "StockRequired", Message = "Stok miktarı boş geçilemez." };
        public static readonly Error UserIdRequired = new Error { Code = "UserIdRequired", Message = "UserId boş geçilemez." };
        public static readonly Error ProductIdRequired = new Error { Code = "ProductIdRequired", Message = "ProductId boş geçilemez." };
        public static readonly Error QtyRequired = new Error { Code = "QtyRequired", Message = "Adet boş geçilemez." };
        public static readonly Error QtyMustBeGreaterThan = new Error { Code = "QtyMustBeGreaterThan", Message = "Adet 0'dan büyük olmalıdır." };

    }
}
