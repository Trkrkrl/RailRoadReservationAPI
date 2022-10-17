
# DemirYolu Rezervasyon Uygulaması

<br/>
Adı girilen Tren hattında talep edilen miktarda yer olup olmadığını belirten API uygulaması.
<br/>

#### Kurallar Ve Kullanım

<br/>

Kapasite %70' e gelmiş ise rezervasyon yapılamaz.

<br/>
.Net 6 web api uygulaması.
- Layered Architecture Design Pattern
- Repository Design Pattern
- Restful API
- Result Types
- Autofac 

- Proje için Database oluşturulması gereklidir. Bu projede PostgreSQl tercih edilmiştir.
- Kendi Database erişim bilgilerinizi appsetting.json dosyasındaki ilgili yere giriniz.
- Daha sonra migration oluşturmak için Visual studioda Package Manager Console'u açınız. Bilmeyenler için  sol üstteki View > other Windows > Package Manager Console.
- Package Manager Console 'da DataAccess'i seçiniz'(deffault olarak WebApi seçilidir) ve  Add-Migraiton mig_10  kodunu çalıştırınız . en son 09 yapıldığından dolayı 10 , sayıyı kendiniz belirleyebilirsiniz.
- Migration başarılı bir şekilde gerçekleştikten sonra Update-Database komutunu çalıştırın. Bu komut da başarılı bir şekilde çallıştıysauygulamamız çalıştırılmaya hazır demektir.

<br/>

İstek yapılırken "çoklu vagondan rezervasyon yapılabilir"  seçeneği için true veya false seçilmeli.

<br/>

Eğer çoklu vagon istenmiyorsa uygulama tüm yolcuları tek bir vagona yerleştimeye çalışır, başarısız olursa boş bir array döner ve rezervasyon yapılamaz der.

<br/>



#### Görsel 1 : Kulanılan Train Tablosu

<br/>

<img src="https://github.com/Trkrkrl/RailRoadReservationAPI/blob/master/Images/TrainsTable.png">

<br/>


#### Görsel 2 : Kulanılan Vagon Tablosu ve Yolcu Kapasiteleri

<br/>

<img src="https://github.com/Trkrkrl/RailRoadReservationAPI/blob/master/Images/Vagons%20Table.png">



<br/>

#### Görsel 3 : Çoklu Vagon Seçilebilir ve Fazla Yolcu Durumu


<br/>

<img src="https://github.com/Trkrkrl/RailRoadReservationAPI/blob/master/Images/distributed-true-overlaod%20test.png">

<br/>


#### Görsel 4 : Çoklu Vagon Seçilemez ve Fazla Yolcu Durumu


<br/>

<img src="https://github.com/Trkrkrl/RailRoadReservationAPI/blob/master/Images/distributed-false-overloadtest.png">

<br/>


#### Görsel 5 : Çoklu Vagon Seçilebilir ve Yeterli Yolcu Durumu


<br/>

<img src="https://github.com/Trkrkrl/RailRoadReservationAPI/blob/master/Images/distributed-true-low%20passenger.png">


<br/>


#### Görsel 6 : Çoklu Vagon Seçilebilemez ve Yeterli Yolcu Durumu


<br/>

<img src="https://github.com/Trkrkrl/RailRoadReservationAPI/blob/master/Images/distributed-false-overloadtest.png">