using KemerburgazPetShop.DataAccess.Concrete.EFCore;
using KemerburgazPetShop.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KemerburgazPetShop.DataAccess.Concrete.EfCore
{
    public static class SeedDatabase
    {
        public static void Seed()
        {
            var context = new PetShopContext();

            if (context.Database.GetPendingMigrations().Count() == 0)
            {
                if (context.Categories.Count() == 0)
                {
                    context.Categories.AddRange(Categories);
                }

                if (context.Products.Count() == 0)
                {
                    context.Products.AddRange(Products);
                    context.AddRange(ProductCategory);
                }

                context.SaveChanges();
            }
        }

        private static Category[] Categories =
        {
            new Category() {CategoryName="Yaş Mama" },
            new Category() {CategoryName="Köpek Kuru Mama" },
            new Category() {CategoryName="Kedi Kuru Mama" },
            new Category() {CategoryName="Kuru Mamalar" }
        };



        private static Product[] Products =
        {
            new Product() {ProductName="Culinary Creations Yetiskin Kedi Maması", ProductPrice=2120, ImageURL="culinary_1.jpg", ProductDescription="Yeni doğmuş kedi ve köpek yavrularından ileri yaşlardaki kedi ve köpeklere kadar evcil hayvanlar için üretilen, biyoloji temelli mamalar görebileceğiniz, hissedebileceğiniz ve güvenebileceğiniz farklılıklarla hep bir adım önde."},
            new Product() {ProductName="No Grain Yavru Tavuklu Mama", ProductPrice=2200, ImageURL="nograinkitten_1.jpg", ProductDescription="Yeni doğmuş kedi ve köpek yavrularından ileri yaşlardaki kedi ve köpeklere kadar evcil hayvanlar için üretilen, biyoloji temelli mamalar görebileceğiniz, hissedebileceğiniz ve güvenebileceğiniz farklılıklarla hep bir adım önde."},
            new Product() {ProductName="No Grain Yetişkin Tavuklu Mama", ProductPrice=1850, ImageURL="nograinadult_1.jpg", ProductDescription="Yeni doğmuş kedi ve köpek yavrularından ileri yaşlardaki kedi ve köpeklere kadar evcil hayvanlar için üretilen, biyoloji temelli mamalar görebileceğiniz, hissedebileceğiniz ve güvenebileceğiniz farklılıklarla hep bir adım önde."},
            new Product() {ProductName="Perfect Digestion Yavru Kedi Maması", ProductPrice=1250, ImageURL="digestioncat_3.jpg", ProductDescription="Yeni doğmuş kedi ve köpek yavrularından ileri yaşlardaki kedi ve köpeklere kadar evcil hayvanlar için üretilen, biyoloji temelli mamalar görebileceğiniz, hissedebileceğiniz ve güvenebileceğiniz farklılıklarla hep bir adım önde."},
            new Product() {ProductName="Sensitive Stomach Skin Adult Cat Food with Chicken", ProductPrice=1460, ImageURL="sensitive_1.jpg", ProductDescription="Yeni doğmuş kedi ve köpek yavrularından ileri yaşlardaki kedi ve köpeklere kadar evcil hayvanlar için üretilen, biyoloji temelli mamalar görebileceğiniz, hissedebileceğiniz ve güvenebileceğiniz farklılıklarla hep bir adım önde."},
            new Product() {ProductName="Sterilised Genç Yetişkin Ördekli Kedi Maması", ProductPrice=1620, ImageURL="sterilordek_1.jpg", ProductDescription="Yeni doğmuş kedi ve köpek yavrularından ileri yaşlardaki kedi ve köpeklere kadar evcil hayvanlar için üretilen, biyoloji temelli mamalar görebileceğiniz, hissedebileceğiniz ve güvenebileceğiniz farklılıklarla hep bir adım önde."},
            new Product() {ProductName="Sterilised Genç Yetişkin Tavuklu Kedi Maması", ProductPrice=1330, ImageURL="steriltavuk_1.jpg", ProductDescription="Yeni doğmuş kedi ve köpek yavrularından ileri yaşlardaki kedi ve köpeklere kadar evcil hayvanlar için üretilen, biyoloji temelli mamalar görebileceğiniz, hissedebileceğiniz ve güvenebileceğiniz farklılıklarla hep bir adım önde."},
            new Product() {ProductName="Sterilised Genç Yetişkin Ton Balıklı Kedi Maması", ProductPrice=1470, ImageURL="steriltonbalık_1.jpg", ProductDescription="Yeni doğmuş kedi ve köpek yavrularından ileri yaşlardaki kedi ve köpeklere kadar evcil hayvanlar için üretilen, biyoloji temelli mamalar görebileceğiniz, hissedebileceğiniz ve güvenebileceğiniz farklılıklarla hep bir adım önde."},
            new Product() {ProductName="Sterilised Mature Adult 7+ Cat Food with Chicken", ProductPrice=2300, ImageURL="mature_1.jpg", ProductDescription="Yeni doğmuş kedi ve köpek yavrularından ileri yaşlardaki kedi ve köpeklere kadar evcil hayvanlar için üretilen, biyoloji temelli mamalar görebileceğiniz, hissedebileceğiniz ve güvenebileceğiniz farklılıklarla hep bir adım önde."},
            new Product() {ProductName="Sterilised Yavru Tavuklu Kedi Maması", ProductPrice=2330, ImageURL="sterilyavru_1.jpg", ProductDescription="Yeni doğmuş kedi ve köpek yavrularından ileri yaşlardaki kedi ve köpeklere kadar evcil hayvanlar için üretilen, biyoloji temelli mamalar görebileceğiniz, hissedebileceğiniz ve güvenebileceğiniz farklılıklarla hep bir adım önde."},

            new Product() {ProductName="Culinary Creations Yetiskin Orta Irk Köpek Maması", ProductPrice=1560, ImageURL="culinarydog_1.jpg", ProductDescription="Yeni doğmuş kedi ve köpek yavrularından ileri yaşlardaki kedi ve köpeklere kadar evcil hayvanlar için üretilen, biyoloji temelli mamalar görebileceğiniz, hissedebileceğiniz ve güvenebileceğiniz farklılıklarla hep bir adım önde."},
            new Product() {ProductName="Orta Irk Kuzu Etli & Pirinçli Yavru Köpek Maması", ProductPrice=1370, ImageURL="ortayavru_1.jpg", ProductDescription="Yeni doğmuş kedi ve köpek yavrularından ileri yaşlardaki kedi ve köpeklere kadar evcil hayvanlar için üretilen, biyoloji temelli mamalar görebileceğiniz, hissedebileceğiniz ve güvenebileceğiniz farklılıklarla hep bir adım önde."},
            new Product() {ProductName="Perfect Digestion Kücük Irk Yavru Köpek Maması", ProductPrice=1860, ImageURL="digestion_1.jpg", ProductDescription="Yeni doğmuş kedi ve köpek yavrularından ileri yaşlardaki kedi ve köpeklere kadar evcil hayvanlar için üretilen, biyoloji temelli mamalar görebileceğiniz, hissedebileceğiniz ve güvenebileceğiniz farklılıklarla hep bir adım önde."},
            new Product() {ProductName="Small Mini Adult Kuzu Etli ve Pirinçli Köpek Maması", ProductPrice=1790, ImageURL="mini_1.jpg", ProductDescription="Yeni doğmuş kedi ve köpek yavrularından ileri yaşlardaki kedi ve köpeklere kadar evcil hayvanlar için üretilen, biyoloji temelli mamalar görebileceğiniz, hissedebileceğiniz ve güvenebileceğiniz farklılıklarla hep bir adım önde."},
            new Product() {ProductName="Small Mini Tavuklu Yavru Köpek Maması", ProductPrice=1440, ImageURL="small_1.jpg", ProductDescription="Yeni doğmuş kedi ve köpek yavrularından ileri yaşlardaki kedi ve köpeklere kadar evcil hayvanlar için üretilen, biyoloji temelli mamalar görebileceğiniz, hissedebileceğiniz ve güvenebileceğiniz farklılıklarla hep bir adım önde."}
        };

        private static ProductCategory[] ProductCategory =
        {
            new ProductCategory() {Product=Products[0],Category=Categories[2]},
            new ProductCategory() {Product=Products[1],Category=Categories[2]},
            new ProductCategory() {Product=Products[2],Category=Categories[2]},
            new ProductCategory() {Product=Products[3],Category=Categories[2]},
            new ProductCategory() {Product=Products[4],Category=Categories[2]},
            new ProductCategory() {Product=Products[5],Category=Categories[2]},
            new ProductCategory() {Product=Products[6],Category=Categories[2]},
            new ProductCategory() {Product=Products[7],Category=Categories[2]},
            new ProductCategory() {Product=Products[8],Category=Categories[2]},
            new ProductCategory() {Product=Products[9],Category=Categories[2]},
            new ProductCategory() {Product=Products[10],Category=Categories[1]},
            new ProductCategory() {Product=Products[11],Category=Categories[1]},
            new ProductCategory() {Product=Products[12],Category=Categories[1]},
            new ProductCategory() {Product=Products[13],Category=Categories[1]},
            new ProductCategory() {Product=Products[14],Category=Categories[1]},

            new ProductCategory() {Product=Products[0],Category=Categories[3]},
            new ProductCategory() {Product=Products[1],Category=Categories[3]},
            new ProductCategory() {Product=Products[2],Category=Categories[3]},
            new ProductCategory() {Product=Products[3],Category=Categories[3]},
            new ProductCategory() {Product=Products[4],Category=Categories[3]},
            new ProductCategory() {Product=Products[5],Category=Categories[3]},
            new ProductCategory() {Product=Products[6],Category=Categories[3]},
            new ProductCategory() {Product=Products[7],Category=Categories[3]},
            new ProductCategory() {Product=Products[8],Category=Categories[3]},
            new ProductCategory() {Product=Products[9],Category=Categories[3]},
            new ProductCategory() {Product=Products[10],Category=Categories[3]},
            new ProductCategory() {Product=Products[11],Category=Categories[3]},
            new ProductCategory() {Product=Products[12],Category=Categories[3]},
            new ProductCategory() {Product=Products[13],Category=Categories[3]},
            new ProductCategory() {Product=Products[14],Category=Categories[3]}
        };
    }
}
