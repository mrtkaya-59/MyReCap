using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
   public  interface IResult
    {
        // İşlem sonucu ve mesajlar olacak burada 
         bool Success { get; } //sonuç başarılımı değilmi
         string Message { get; } // sonuca göre mesaj olacak


    }
}
