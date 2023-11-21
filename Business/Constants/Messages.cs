using Core.Entities.Concrete;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages
    {
        public static string BookAdded = "Ürün eklendi";
        public static string BookInvalid = "Ürün ismi geçersiz";
        public static string BooksListed = "Ürünler listelendi";
        public static string MaintenanceTime = "Sistem bakımda";
        public static string BookCountOfCategoryError = "Bu kategoride max ürüne ulaşıldı";
        public static string BookAlreadyExist = "Bu isim zaten var";
        public static string? AuthorizationDenied = "Yetkiniz yok";
        public static string UserRegistered = "User kayıt oldu";
        public static User UserNotFound;
        public static User PasswordError;
        public static string SuccessfulLogin = "Başarılı giriş " ;
        public static string UserAlreadyExists = "User zaten var";
        public static string AccessTokenCreated = "Token oluşturuldu";
    }
}
