﻿using Business.Queries.UserQueries;
using System.Collections.Generic;

namespace Business.Constants
{
    public static class Messages
    {
        public static string LoginFailed = "Mail veya şifrenizi kontrol ediniz.";
        public static string LoginSuccessful = "Oturum açma işlemi başarılı.";
        public static string EmailAlreadyExist = "Farklı bir mail adresi deneyin";
        public static string RegistrationIsSuccessful = "Üyelik işlemi başarılı";

        public static string UserList = "Kullanıcılar listelendi";

        public static string UserNotFound = "Kullanıcı bulunamadı";

        public static string PostingsIAppliedSuccesful = "Başvuru yaptığınız ilanlar başarıyla listelendi";

        public static string JobPostingAddSuccessful = "İş ilanı başarılı bir şekilde eklendi";
        public static string PhotoSuccesfulUpdated = "Fotoğraf başarılı bir şekilde güncellendi";

        public static string PhotoFileIsEmpty ="Fotoğraf Dosyası Boş Olmamalı";

        public static string ResumeSuccesfulAdded = "Öz geçmiş dosyanız başarılı bir şekilde kaydedildi";
        public static string ResumeFileIsEmpty = "Öz geçmiş dosyası boş olmamalı";

        public static string UserJobAppApplicationSuccesful = "İş başvuru işlemi başarılı";

        public static string GetResumeSuccesful = "Özgeçmişler başarılı bir şekilde listelendi";
    }
}
