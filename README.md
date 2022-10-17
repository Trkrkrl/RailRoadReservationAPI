
# DemirYolu Rezervasyon Uygulaması

<br/>
Adı girilen Tren hattında talep edilen miktarda yer olup olmadığını belirten API uygulaması.
<br/>

#### Kurallar Ve Kullanım

<br/>

Kapasite %70' e gelmiş ise rezervasyon yapılamaz.

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

<https://github.com/Trkrkrl/RailRoadReservationAPI/blob/master/Images/distributed-false-overloadtest.png">

<br/>


#### Görsel 5 : Çoklu Vagon Seçilebilir ve Yeterli Yolcu Durumu


<br/>

<img src="https://github.com/Trkrkrl/RailRoadReservationAPI/blob/master/Images/distributed-true-low%20passenger.png">


<br/>


#### Görsel 6 : Çoklu Vagon Seçilebilemez ve Yeterli Yolcu Durumu


<br/>

<img src="https://github.com/Trkrkrl/RailRoadReservationAPI/blob/master/Images/distributed-false-overloadtest.png">