using CosmeticTrade.DAL.ORM.Context;
using CosmeticTrade.DAL.ORM.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CosmeticTrade.DAL.ORM.Tools
{
    public class DataInitializer : DropCreateDatabaseIfModelChanges<DataContext>
    {
        protected override void Seed(DataContext context)
        {
            var categories = new List<Category>()
            {
               new Category(){Name="ALLIK",Description=" Yanaklara doğal bir kızarıklık vermeyi amaçlayan, genelde toz halde üretilen makyaj malzemesidir. Yanaklara sanki hafif utangaçlıktan, heyecandan, telaştan veya pozitif fazla enerjiden dolayı hafifçe kızarmış gibi bir görünüm verir.Allık aynı zamanda makyajla yüz şekillendirme ve yüz boyutlandırmada önemli bir rol oynar."},
               new Category(){Name="FAR",Description=" Farlar göz kapağı için kullanılan kozmetik ürünleridir. Göz makyajının olmazsa olmazı haline gelmişlerdir. Oldukça geniş bir renk yelpazesine sahip olan farlar, hem günlük makyajda hem özel gün makyajlarında vazgeçilmez ürünler olmuşlardır.Göz farları değişik formlarda karşımıza çıkabilmektedirler. Genellikle kullanılan toz formundaki farlardır. Bunun yanında pres far, krem far, kalem far, köpük farlar da oldukça geniş bir kullanım alanına sahiptirler."},
               new Category(){Name="FONDÖTEN",Description=" Cilt tonunu eşitleme ve kusurları gizleme özelliğine sahip bu yüz makyaj ürünü, birçok firma tarafından farklı ton seçenekleri ve özellikler ile piyasaya sunulmaktadır. Doğru ton ve ürün seçimi ve doğru uygulama ile cilt üzerinde pürüzsüz bir görünüm sağlayan bu ürün, aynı zamanda pudra ve allık için cildi hazırlamaktadır."},
               new Category(){Name="RUJ",Description="Kadınların vazgeçilmez makyaj ürünleri arasında ilk sırada yer alan ruj, dudak makyajının temel ürünü olma özelliğine sahiptir. Dudak renklendirme, hem hafif makyajda hem de özel günlerde yapılan özel makyajlarda mutlaka uygulanan bir yöntemdir. Yılın trendlerine, cilt rengine, seçilen makyaj tonuna, tarza ve kıyafetlere göre belirlenen ruj renkleri, her geçen gün daha fazla seçenek sunmaktadır."},
               new Category(){Name="RİMEL",Description="Rimel göz güzelliği için kullanılan bir çok farklı bileşenden oluşarak farklı firmalar tarafından üretilen kirpik boyasıdır. Rimel Boya içeren bir kap içinde bulunan renkli kozmetik yarı sıvı malzeme ve bu malzemeyi kirpiklere sürebilmek için bir fırça bulunur . Rimelin diğer adı Maskara dır ( Mascara ). Günümüzde silikon içeren kirpik kalınlaştırıcı ürünlerin yanı sıra sabit yani zor çıkan, akmayan rimel türleri de vardır."},
               new Category(){Name="OJE",Description="Mısırlıların, tarihte toplumsal sınıfları belirlemek amacı ile kullandığı tırnak boyları, günümüzde her tarz ve yaş grubundan kadınların en çok kullandığı kozmetik ürünleri arasında yer almaktadır. Tırnak bakımının vazgeçilmez öğeleri arasında yer alan Oje, hem el hem de ayak tırnaklarına renk katarken, günümüz teknolojisiyle üretilen ürünler aynı zamanda tırnak bakımına da destek olmaktadır."},
               new Category(){Name="PUDRA",Description="Ten makyajının en çok kullanılan ürünleri arasında yer alan Pudra, makyajı sabitlemek ve öncesinde kullanılan likit ürünlerin çizgileri belirginleştirmesini önlemenin yanı sıra, cilde mat bir görünüm kazandırma amacı ile kullanılmaktadır. Bu makyaj ürünü, fondöten üzerine kullanılabildiği gibi, tek başına kullanım için de uygun ürünler arasında yer almaktadır. Ciltte mat görünüm kazandırmaya yardımcı ürünlerden biri olmasından dolayı, özellikle yağlı ve karma cilde sahip kişiler tarafından en çok kullanılan makyaj ürünlerinden biridir."},
               new Category(){Name="PARFÜM",Description="Kokular, ruhsal ve davranışsal durumumuzu etkileyerek farklılaştırabilir. Kokuların; mutlu, sakin, çekici, kendine güvenen, hüzünlü ve daha birçok duygusal tepkilerimiz üzerinde etkili roller üstlenebildikleri, yapılan araştırmalarla kanıtlanmaktadır."}
            };

            foreach (var category in categories)
            {
                context.Categories.Add(category);
            }

            context.SaveChanges();


            List<Product> products = new List<Product>()
            {
               new Product(){Name="KissMeMoreLipTattoo",Description="Long Lasting Matte Liquid Lipstick",Brand="Flormar",Code="4001",Price=44.99m,Stock=500,CategoryId=4,Images=new List<Image>(){new Image() { ImageUrl= "/Content/Images/PLimg/KissMeMore1.jpg" },new Image() { ImageUrl= "/Content/Images/PLimg/KissMeMore2.jpg" },new Image() { ImageUrl= "/Content/Images/PLimg/KissMeMore3.jpg" },new Image() { ImageUrl= "/Content/Images/PLimg/KissMeMore4.jpg" }}},
               new Product(){Name="GoldenRoseDreamLipsLipliner526",Description="Long Lasting Matte Liquid Lipstick",Brand="GoldenRose",Code="4002",Price=5.99m,Stock=200,CategoryId=4,Images=new List<Image>(){new Image() { ImageUrl= "/Content/Images/PLimg/GoldenRoseDreamLipsLipliner526-6.jpg" } }},
               new Product(){Name="BabyLipsBalm-Blush",Description="Long Lasting Matte Liquid Lipstick",Brand="Maybelline",Code="4003",Price=14.99m,Stock=290,CategoryId=4,Images=new List<Image>(){new Image() { ImageUrl= "/Content/Images/PLimg/MaybellineNewYorkBabyLipsBalm-Blush-15.jpg" } }},
               new Product(){Name="NudeRuj536",Description="Full coverage, high pigment, matte finish lipstick. With a unique crystal bullet design that is ideal for lining on application for ultimate precision.",Brand="Pastel",Code="4004",Price=21.99m,Stock=400,CategoryId=4,Images=new List<Image>(){new Image() { ImageUrl= "/Content/Images/PLimg/pastelNudeRuj536-21.jpg" } }},
               new Product(){Name="ColorUp03BrownishNude",Description="Curated mix of classic shades in a creamy satin formula. Easy to apply with a shade for every occasion – collect them all.",Brand="Flormar",Code="4005",Price=36.99m,Stock=50,CategoryId=4,Images=new List<Image>(){new Image() { ImageUrl= "/Content/Images/PLimg/FlormarColorUpLipCrayonRuj03BrownishNude-37.jpg" } }},
                new Product(){Name="LipTattoo04peach",Description="Long Lasting Matte Liquid Lipstick",Brand="GoldenRose",Code="4006",Price=8.99m,Stock=270,CategoryId=4,Images=new List<Image>(){new Image() { ImageUrl= "/Content/Images/PLimg/GoldenRoseLipBalmPomeGranateSpf15nar-9.jpg" } }},
               new Product(){Name="DeluxeShineGlossd36ruj",Description="Curated mix of classic shades in a creamy satin formula. Easy to apply with a shade for every occasion – collect them all.",Brand="Flormar",Code="4007",Price=31.99m,Stock=200,CategoryId=4,Images=new List<Image>(){new Image() { ImageUrl= "/Content/Images/PLimg/FlormarDeluxeShineGlossd36ruj-32.jpg" } }},
               new Product(){Name="ColorSensational92DivineWine",Description="Curated mix of classic shades in a creamy satin formula. Easy to apply with a shade for every occasion – collect them all.",Brand="Maybelline",Code="4008",Price=9.99m,Stock=100,CategoryId=4,Images=new List<Image>(){new Image() { ImageUrl= "/Content/Images/PLimg/maybellineNewYorkColorSensationalDudakKalemi92DivineWine-26.jpg" } }},
               new Product(){Name="HdWeightlessMAtteRuj15Mocha",Description="Full coverage, high pigment, matte finish lipstick. With a unique crystal bullet design that is ideal for lining on application for ultimate precision.",Brand="Flormar",Code="4009",Price=44.99m,Stock=200,CategoryId=4,Images=new List<Image>(){new Image() { ImageUrl= "/Content/Images/PLimg/FlormarHdWeightlessMAtteRuj15Mocha.jpg" } }},
               new Product(){Name="NudeLookPerfectMatteLipstick03",Description="Full coverage, high pigment, matte finish lipstick. With a unique crystal bullet design that is ideal for lining on application for ultimate precision.",Brand="GoldenRose",Code="4010",Price=27.99m,Stock=60,CategoryId=4,Images=new List<Image>(){new Image() { ImageUrl= "/Content/Images/PLimg/GoldenRoseNudeLookPerfectMatteLipstick03-28.jpg" } }},
               new Product(){Name="ColorSensationalMadeForAll",Description="Curated mix of classic shades in a creamy satin formula. Easy to apply with a shade for every occasion – collect them all.",Brand="Maybelline",Code="4011",Price=25.99m,Stock=200,CategoryId=4,Images=new List<Image>(){new Image() { ImageUrl= "/Content/Images/PLimg/MaybellineNewYorkColorSensationalMadeForAll-26.jpg" } }},
               new Product(){Name="LipBalmBlackMulberry02Redesing",Description="Full coverage, high pigment, matte finish lipstick. With a unique crystal bullet design that is ideal for lining on application for ultimate precision.",Brand="Flormar",Code="4013",Price=21.99m,Stock=300,CategoryId=4,Images=new List<Image>(){new Image() { ImageUrl= "/Content/Images/PLimg/FlormarLipBalmBlackMulberry02Redesing-22.jpg" } }},
               new Product(){Name="VelvetMatterujlipstickno31",Description="Long Lasting Matte Liquid Lipstick",Brand="GoldenRose",Code="4014",Price=18.99m,Stock=200,CategoryId=4,Images=new List<Image>(){new Image() { ImageUrl= "/Content/Images/PLimg/GoldenRoseVelvetMatterujlipstickno31-18,90.jpg" } }},
               new Product(){Name="ColorSensationalSmokedRoses",Description="Full coverage, high pigment, matte finish lipstick. With a unique crystal bullet design that is ideal for lining on application for ultimate precision.",Brand="Maybelline",Code="4015",Price=25.99m,Stock=500,CategoryId=4,Images=new List<Image>(){new Image() { ImageUrl= "/Content/Images/PLimg/MaybellineNewYorkColorSensationalSmokedRoses-26.jpg" } }},
               new Product(){Name="SupermatteLipstick",Description="Full coverage, high pigment, matte finish lipstick. With a unique crystal bullet design that is ideal for lining on application for ultimate precision.",Brand="Flormar",Code="4016",Price=31.99m,Stock=2,CategoryId=4,Images=new List<Image>(){new Image() { ImageUrl= "/Content/Images/PLimg/FlormarSupermatteLipstick-32.jpg" } }},
               new Product(){Name="VelvetMatterujlipstickno31",Description="Full coverage, high pigment, matte finish lipstick. With a unique crystal bullet design that is ideal for lining on application for ultimate precision.",Brand="GoldenRose",Code="4016",Price=18.99m,Stock=200,CategoryId=4,Images=new List<Image>(){new Image() { ImageUrl= "/Content/Images/PLimg/GoldenRoseVelvetMatterujlipstickno31-18,90.jpg" } }},
               new Product(){Name="Matte935CinnamonSpice",Description="Long Lasting Matte Liquid Lipstick",Brand="Maybelline",Code="4016",Price=24.90m,Stock=200,CategoryId=4,Images=new List<Image>(){new Image() { ImageUrl= "/Content/Images/PLimg/935CinnemonSpice1.jpg" },new Image() { ImageUrl= "/Content/Images/PLimg/935CinnemonSpice2.jpg" },new Image() { ImageUrl= "/Content/Images/PLimg/935CinnemonSpice3.jpg"}}},
               new Product(){Name="SuperMatteLipstick206",Description="Curated mix of classic shades in a creamy satin formula. Easy to apply with a shade for every occasion – collect them all.",Brand="Flormar",Code="4016",Price=31.99m,Stock=200,CategoryId=4,Images=new List<Image>(){new Image() { ImageUrl= "/Content/Images/PLimg/FlormarSuperMatteLipstick206-32.jpg" } }},


               new Product(){Name="Flormar Satin Matte Allık 05 Peach Brown",Description="Renk seçenegi mevcuttur.",Brand="Flormar",Code="1001",Price=32.5m,Stock=200,CategoryId=1,Images=new List<Image>(){new Image() { ImageUrl= "/Content/Images/PLimg/Flormar05peachbrown.jpg" } }},
               new Product(){Name="Golden Rose Nude Look Face Baked Blusher Peachy Nude",Description="Renk seçenegi mevcuttur.",Brand="GoldenRose",Code="1002",Price=23.3m,Stock=200,CategoryId=1,Images=new List<Image>(){new Image() { ImageUrl= "/Content/Images/PLimg/GRBakedblusher.jpg" } }},
               new Product(){Name="Maybelline New York Fit Me Blush 40 Peach",Description="Renk seçenegi mevcuttur.",Brand="Maybelline",Code="1003",Price=29.9m,Stock=200,CategoryId=1,Images=new List<Image>(){new Image() { ImageUrl= "/Content/Images/PLimg/Mblush40peach1.jpg" },new Image() { ImageUrl= "/Content/Images/PLimg/Mblush40peach2.jpg" },new Image() { ImageUrl= "/Content/Images/PLimg/Mblush40peach3.jpg" },new Image() { ImageUrl= "/Content/Images/PLimg/Mblush40peach4.jpg" } }},
               new Product(){Name="Show By Pastel Show Your Mood Blush Set Wild No:441",Description="Renk seçenegi mevcuttur.",Brand="Pastel",Code="1004",Price=27.3m,Stock=200,CategoryId=1,Images=new List<Image>(){new Image() { ImageUrl= "/Content/Images/PLimg/Pblush441.jpg" } }},


               new Product(){Name="Pastel Nude Far Tekli 75",Description="Renk seçenegi mevcuttur.",Brand="Pastel",Code="2001",Price=12.3m,Stock=200,CategoryId=2,Images=new List<Image>(){new Image() { ImageUrl= "/Content/Images/PLimg/pastelfar75.jpg" } }},
               new Product(){Name="Flormar Quarted Far 402",Description="Renk seçenegi mevcuttur.",Brand="Flormar",Code="2002",Price=31.9m,Stock=200,CategoryId=2,Images=new List<Image>(){new Image() { ImageUrl= "/Content/Images/PLimg/FlormarQuartedfar402.jpg" } }},
               new Product(){Name="Golden Rose Professional Palette No:109 Far",Description="Renk seçenegi mevcuttur.",Brand="GoldenRose",Code="2003",Price=23.3m,Stock=200,CategoryId=2,Images=new List<Image>(){new Image() { ImageUrl= "/Content/Images/PLimg/GRPalette109far.jpg" } }},
               new Product(){Name="Maybelline New York Eyeshadow Palette Blushed Nudes",Description="Renk seçenegi mevcuttur.",Brand="Maybelline",Code="2004",Price=44.9m,Stock=200,CategoryId=2,Images=new List<Image>(){new Image() { ImageUrl= "/Content/Images/PLimg/Meyeshadowpaletteblushednudes.jpg" } }},


               new Product(){Name="Flormar Mat Touch M306 Fondöten Pastelle",Description="Renk seçenegi mevcuttur.",Brand="Flormar",Code="3001",Price=50.9m,Stock=200,CategoryId=3,Images=new List<Image>(){new Image() { ImageUrl= "/Content/Images/PLimg/FlarmarfondötenM306.jpg" } }},
               new Product(){Name="Maybelline New York Fit Me Matte+Poreless Fondöten 110 Porcelain",Description="Renk seçenegi mevcuttur.",Brand="Maybelline",Code="3002",Price=29.9m,Stock=200,CategoryId=3,Images=new List<Image>(){new Image() { ImageUrl= "/Content/Images/PLimg/Mfondöten110porcelain.jpg" } }},
               new Product(){Name="Golden Rose Total Cover 2'in 1 Foundation&Concealer Mini Boy No:12",Description="Renk seçenegi mevcuttur.",Brand="GoldenRose",Code="3003",Price=7.9m,Stock=200,CategoryId=3,Images=new List<Image>(){new Image() { ImageUrl= "/Content/Images/PLimg/GRfoundationConcealer12.jpg" } }},
               new Product(){Name="Golden Rose Nude Radiant Tinted Moisturıser 02 Mediumtint",Description="Renk seçenegi mevcuttur.",Brand="GoldenRose",Code="3004",Price=35.4m,Stock=200,CategoryId=3,Images=new List<Image>(){new Image() { ImageUrl= "/Content/Images/PLimg/GRmoisturiser02-1.jpg" },new Image() { ImageUrl= "/Content/Images/PLimg/GRmoisturiser02-2.jpg" }}},
               new Product(){Name="Pastel Silky Dream Fondöten 353",Description="Renk seçenegi mevcuttur.",Brand="Pastel",Code="3001",Price=32.9m,Stock=200,CategoryId=3,Images=new List<Image>(){new Image() { ImageUrl= "/Content/Images/PLimg/pastelfondöten353.jpg" } }},


               new Product(){Name="Maybelline New York Lash Sensational Extra Black",Description="Renk seçenegi mevcuttur.",Brand="Maybelline",Code="5001",Price=35.9m,Stock=200,CategoryId=5,Images=new List<Image>(){new Image() { ImageUrl= "/Content/Images/PLimg/MLashSensastionalextrablack1.jpg" },new Image() { ImageUrl= "/Content/Images/PLimg/MLashSensastionalextrablack2.jpg" },new Image() { ImageUrl= "/Content/Images/PLimg/MLashSensastionalextrablack3.jpg" },new Image() { ImageUrl= "/Content/Images/PLimg/MLashSensastionalextrablack4.jpg" } }},
               new Product(){Name="Flormar X10 Lengthening Sculpting Maskara",Description="Renk seçenegi mevcuttur.",Brand="Flormar",Code="5002",Price=25.9m,Stock=200,CategoryId=5,Images=new List<Image>(){new Image() { ImageUrl= "/Content/Images/PLimg/Flormarx10maskara.jpg" } }},
               new Product(){Name="Golden Rose Fantastic 3D Lash Mascara",Description="Renk seçenegi mevcuttur.",Brand="GoldenRose",Code="5003",Price=18.9m,Stock=200,CategoryId=5,Images=new List<Image>(){new Image() { ImageUrl= "/Content/Images/PLimg/GRfantastic3Dmascara.jpg" } }},
               new Product(){Name="Pastel Multidimensional Volume&Curl Mascara",Description="Renk seçenegi mevcuttur.",Brand="Pastel",Code="5004",Price=27.3m,Stock=200,CategoryId=5,Images=new List<Image>(){new Image() { ImageUrl= "/Content/Images/PLimg/Pmultidimensionalmascara.jpg" } }},


               new Product(){Name="Flormar Matte Oje M45",Description="Renk seçenegi mevcuttur.",Brand="Flormar",Code="6001",Price=9.9m,Stock=200,CategoryId=6,Images=new List<Image>(){new Image() { ImageUrl= "/Content/Images/PLimg/Flormarmatteojem45.jpg" } }},
               new Product(){Name="Flormar Matte Oje M55",Description="Renk seçenegi mevcuttur.",Brand="Flormar",Code="6001",Price=8.9m,Stock=200,CategoryId=6,Images=new List<Image>(){new Image() { ImageUrl= "/Content/Images/PLimg/Flormarmatteojem55.jpg" } }},
               new Product(){Name="Golden Rose Color Expert Oje 106",Description="Renk seçenegi mevcuttur.",Brand="GoldenRose",Code="6002",Price=4.9m,Stock=200,CategoryId=6,Images=new List<Image>(){new Image() { ImageUrl= "/Content/Images/PLimg/GRexpertoje106.jpg" } }},
               new Product(){Name="Golden Rose Color Expert Oje 29",Description="Renk seçenegi mevcuttur.",Brand="GoldenRose",Code="6003",Price=4.9m,Stock=200,CategoryId=6,Images=new List<Image>(){new Image() { ImageUrl= "/Content/Images/PLimg/GRoje29.jpg" } }},
               new Product(){Name="Pastel Nude Oje 761",Description="Renk seçenegi mevcuttur.",Brand="Pastel",Code="6004",Price=5.4m,Stock=200,CategoryId=6,Images=new List<Image>(){new Image() { ImageUrl= "/Content/Images/PLimg/pastelnudeoje761.jpg" } }},
               new Product(){Name="Golden Rose Color Expert Oje 112",Description="Renk seçenegi mevcuttur.",Brand="GoldenRose",Code="6001",Price=4.9m,Stock=200,CategoryId=6,Images=new List<Image>(){new Image() { ImageUrl= "/Content/Images/PLimg/GRoje112.jpg" } }},


               new Product(){Name="Flormar Wet&Dry Compact Powder W04",Description="Renk seçenegi mevcuttur.",Brand="Flormar",Code="7001",Price=56.9m,Stock=200,CategoryId=7,Images=new List<Image>(){new Image() { ImageUrl= "/Content/Images/PLimg/Flormarcompactpowderw04.jpg" } }},
               new Product(){Name="Golden Rose Long Wear Finishing Powder Beyaz",Description="Renk seçenegi mevcuttur.",Brand="GoldenRose",Code="7002",Price=27.5m,Stock=200,CategoryId=7,Images=new List<Image>(){new Image() { ImageUrl= "/Content/Images/PLimg/GRlongWearpowder.jpg" } }},
               new Product(){Name="Maybelline New York Fit Me Matte+Poreless Pudra 120 Classic Ivory",Description="Renk seçenegi mevcuttur.",Brand="Maybelline",Code="7003",Price=29.9m,Stock=200,CategoryId=7,Images=new List<Image>(){new Image() { ImageUrl= "/Content/Images/PLimg/Mpudra120-1.jpg" },new Image() { ImageUrl= "/Content/Images/PLimg/ Mpudra120-2.jpg" },new Image() { ImageUrl= "/Content/Images/PLimg/Mpudra120-3.jpg" }}},
               new Product(){Name="Pastel Pro Fashion Wet&Dry Terracotta Powder 52",Description="Renk seçenegi mevcuttur.",Brand="Pastel",Code="7004",Price=43.9m,Stock=200,CategoryId=7,Images=new List<Image>(){new Image() { ImageUrl= "/Content/Images/PLimg/PastelTerracottaPowder52.jpg" } }},


               new Product(){Name="Ct",Description="Farklı koku seçenekleri mevcuttur.",Brand="Flormar",Code="8001",Price=490m,Stock=200,CategoryId=8,Images=new List<Image>(){new Image() { ImageUrl= "/Content/Images/PLimg/parfüm.jpg" } }}
            };

            foreach (var product in products)
            {
                context.Products.Add(product);
            }
            context.SaveChanges();


            List<Shipper> shippers = new List<Shipper>()
            {
                 new Shipper(){CompanyName="Aras Kargo",Phone="444-25-52"},
                 new Shipper(){CompanyName="MNG Kargo",Phone="444-06-06"},
                 new Shipper(){CompanyName="Yurtiçi Kargo",Phone="444-99-99"},

            };

            foreach (var shipper in shippers)
            {
                context.Shippers.Add(shipper);
            }
            context.SaveChanges();


            List<Role> roles = new List<Role>()
            {
                new Role(){Name="User"},
                new Role(){Name="Admin"},
            };

            foreach (var role in roles)
            {
                context.Roles.Add(role);
            }
            context.SaveChanges();


            var user = new User();
            user.Name = "User";
            user.Surname = "Surname";
            user.Username = "User";
            user.Email = "user@hotmail.com";
            user.ShipAddress = "İstanbul";
            user.Password = "123456";
            user.ConfirmMail = true;
            user.Roles.Add(context.Roles.FirstOrDefault(i => i.Name == "User"));

            context.Users.Add(user);

            var admin = new User();
            admin.Name = "Admin";
            admin.Surname = "Admin";
            admin.Username = "Admin";
            admin.Password = "123456";
            admin.Email = "admin@hotmail.com";
            admin.ShipAddress = "İstanbul";
            admin.ConfirmMail = true;
            admin.Roles.Add(context.Roles.FirstOrDefault(i => i.Name == "Admin"));

            context.Users.Add(admin);


            base.Seed(context);

        }
    }
}
