NegroniRPG
==========

Negroni RPG

Описание на идеята на играта
　　
　　Започва със StartScreen, който е прозорец с абстрактна форма и с функции на стартово меню, където се избират настройки за играта и играч (ще има различни герои, опционално ще имат различни скилове).
　　След избор се отваря прозорец GameScreen.
　　Долу вдясно на шестте празни квадратчета се намира инвентарът. На първа позиция са парите (coins). На останалите са намерените или купени колби за живот и айтеми. Айтемите са helmet, gloves, boots, robe, shield, weapon. Може да има само по един айтем от вид, който стои на предварително определено място в инвентара. Айтемите не могат да се продават. Ако са излишни, могат да се унищожават с натискане на десен бутон на мишката върху айтема от инвентара и потвърждаване в изскачащ прозорец. С натискане на ляв бутон на мишката върху колбите, те се използват.
　　При посочване на айтемите с мишката се изписват имената им в малко черно правоъгълниче, което се появява. Изписва се още и проста информация (примерно Dragon Gloves, 40 def, Staff, 20 dmg). При посочване на живота се изписва 40/50 за 40 точки живот от максимум 50. А при посочване на изображението на избрания играч се изписва името на героя. В полето вдясно от играча се изписват различни съобщения с различни цветове. Записани са в масив, от който се взимат само последните 5 и се изписват като най-новите са най-отгоре. (В зависимост от вида на съобщението трябва да се съдържа и цвета)
　　Чашата с Negroni (алкохолен коктейл) показва кръвта на играча. С намаляване на точките, чашата се изпразва. На полето има кладенче, което пълни на макс живота на играча, но има reuse time от 20-30 секунди. Когато играчът стигне до него, тъй като не може да мине през него, е достатъчно да се опита да го направи, за да го използва. Може и с Enter да стане. (по-просто може да се направи с поле с жива вода, през което, ако се мине, се пълни живота на съответните времеви интервали).
　　На терена се намира магазин, в който се влиза - безопасно място от мобове. Когато играчът влезе, се появява полупрозрачен прозорец, който показва възможните за купуване айтеми и колби за живот и съответно дали играчът има пари за тях. Ако има пари и играчът закупи айтема, но в инвентара вече има айтем от същия вид, тогава излиза прозорец, който пита дали играчът иска да изтрие този от инвентара и да го замести. Ако откаже, транзакцията не се състои.
　　Враговете: Отделните видове мобове могат да се направят като структури (struct) в кода, в които ще се съдържа името им, мощността на удара им, живота им, скоростта им и графиките им (sprites изображенията). За да съдържат всичко необходимо, може да се използва наследяване на интерфейс IMonster. (Същото може да се използва и за плейъра, и за айтемите).
　　Мобовете се spawn-ват на случаен принцип: Random е мястото им на spawn и вида им. При spawn в рандом генератора се изключват позицията на играча, позициите на другите мобове и “системните позиции“ като кладенец и магазин. Има лимит на spawn-атите мобове, който трябва да се проверява (примерно 4-5).
　　Mobs AI: След появяване те започват да се движат по терана на рандом принцип на определени интервали от време (hardcoded). Рандом е посоката на движение и дължината на хода. За генериране на посоката се проверява дали моба не се намира в ъглите на екрана и/ли до “системните позиции” и ако е така, се изключват някои посоки при генерирането на число от 1 до 4 (може да се ползва enum за посоките). След това дължината на хода се определя на принципа randomGenerator.Next(1, (Screen Width или Height) - (mobCurrentPosition.X или mobCurrentPosition.Y), за да се избегне мобът да се скрие от екрана. При изпълнение на хода му, се проверява постоянно за навлизане в Rectangle около играча, който се движи. Ако мобът го доближи, променя движението си и поведението. AI!!! Започва да стреля и да преследва играча.
　　Играчът стреля с огън или ледена стрела по права линия и с определен от оръжието range, т.е. изстелът изчезва на определено разстояние, ако не е достигнал целта. Проверка за колизия.
　　Дроп: Когато мобът умре, на негово място се появява една картинка на една позиция - пари (най-вече), колба (full hp, само от дроп) или един айтем. Те изчезват след 20 сек, ако играчът не мине през това поле, за да ги събере (масив / речник, съдържащ айтемите на земята). Трябва интелигентен random генератор (с процентна възможност) - дали ще са пари или айтем и съответно колко пари и какъв айтем (по-добрите с по-нисък процент).
　　Ако играчът или мобът бъдат улучени, затрептяват, т.е. за няколко секунди се увеличава интервала от време, на който се появява следващия frame от sprite-а на изображението им.
　　
　　GameOver: когато животът стигне 0, се изписва с големи букви GAME OVER.