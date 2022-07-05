void Metod1()
{
    Console.WriteLine("metod1... basla");
    Thread.Sleep(4000);
    Console.WriteLine("metod1... bitis");
}

void Metod2()
{
    Console.WriteLine("metod2... basla");
    Thread.Sleep(7000);
    Console.WriteLine("metod2... bitis");
}

void Islem1()
{
    DateTime d1, d2;
    TimeSpan fark;
    d1 = DateTime.Now;
    Metod1();
    Metod2();
    d2 = DateTime.Now;
    fark = d2 - d1;
    Console.WriteLine(fark.TotalMilliseconds);

}

//void den Task'a cevrildi...2.ornek için
async Task Metod1Async()
{
    Console.WriteLine("metod1... basla");
    await Task.Delay(4000);
    //awaitin kullanılddığı fonk. un async olarak işaretlenmesi lazım!await fnkun beklenmesni sağlar.
    Console.WriteLine("metod1... bitis");
}

//void den Task'a cevrildi...2. ornek için
async Task Metod2Async()
{
    Console.WriteLine("metod2... basla");
    await Task.Delay(7000);
    Console.WriteLine("metod2... bitis");
}

//void Islem2Async()
//{
//    //Metod1 ve Metod2 tetiklenir fakat Islem2 metodların bitisini beklemez...

//    DateTime d1, d2;
//    TimeSpan fark;
//    d1 = DateTime.Now;
//    Metod1Async();
//    Metod2Async();
//    d2 = DateTime.Now;
//    fark = d2 - d1;
//    Console.WriteLine(fark.TotalMilliseconds);

//} eskisi ile aynı zamandatamamlandı.Fakat Islem2Async bitsede kullandığı async metotların bitiini beklemez.

//bu orunları gidermek için altdaki fonksiyonda ilk olarak  52. ve 53.satırdaki metorlara await yazmamız lazım.Böylelikle metodun kendisinide
//async olarak imzalamamız gerekir.Fakat void olan beklemez bu nedenle biz metot1 ve metot2 yi void
//yazdığımız için onları Task olarak değiştirdik.(async void Islem2Async fonk. direek Islem2Async olarak
//çağrılıp çalıştırıldığında bu sefer de bu metot bekletilmediği için sorun oldu bu nedenle metodun kendiside Task olarak
//işaretlenip await olarak çağrıldı.==> Evett birbirlerini beleyip çalışsada yine eşit zaman aralığında oldu!!! 
//asekron kullanımından faydalanmak için ise await Task.WhenAll(Metod1Async(), Metod2Async()); kullanıldı ve artık
//süre azaldı !!
async Task Islem2Async()
{
    DateTime d1, d2;
    TimeSpan fark;
    d1 = DateTime.Now;
    //await Metod1Async();
    //await Metod2Async();

    await Task.WhenAll(Metod1Async(), Metod2Async());

    d2 = DateTime.Now;
    fark = d2 - d1;
    Console.WriteLine(fark.TotalMilliseconds);

}


//Asenkron Programlama
//Bir metodun içerisinde await kullanılacaksa, metod async olarak işaretlenmeli...



//Islem1();
await Islem2Async();