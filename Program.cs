
using System.ComponentModel.Design;
using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using shared.model;



var builder = WebApplication.CreateBuilder(args);

var AllowCors = "_AllowCors";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: AllowCors, builder =>
    {
        builder.AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

var app = builder.Build();
app.UseCors(AllowCors);

Post[] post = new Post[]
{
    new Post(1, "Hvad er hovedstaden i Danmark?", "Hans Vestergaard", 1, DateTime.Now.AddDays(-1),
        new List<Comment>
        {
            new Comment(1, "Bent Bager", "K�benhavn", 1, DateTime.Now, DateTime.Now),
            new Comment(2, "Preben Pedersen", "�rhus, tror jeg? Det har i hvert fald et rigtigt godt museum!", 1, DateTime.Now, DateTime.Now),
            new Comment(3, "Lone Lego", "Er det ikke Legoland?", 1, DateTime.Now, DateTime.Now),
            new Comment(4, "Grethe Gadehopper", "N�h, det m� da v�re Aalborg � de har Jomfru Ane Gade!", 1, DateTime.Now, DateTime.Now)
        }),

    new Post(2, "Hvilket element har det kemiske symbol O?", "Bodil Vestergaard", 1, DateTime.Now.AddDays(-2),
        new List<Comment>
        {
            new Comment(1, "Ib Ildelugt", "Oxygen", 1, DateTime.Now, DateTime.Now),
            new Comment(2, "Flemming Friskpresset", "Orange juice, helt klart!", 1, DateTime.Now, DateTime.Now),
            new Comment(3, "Hanne H�nse�g", "Omelet? Jeg er ret sikker p�, at det st�r for omelet.", 1, DateTime.Now, DateTime.Now),
            new Comment(4, "Gunnar Gouda", "O st�r da for Ost, det ved enhver!", 1, DateTime.Now, DateTime.Now)
        }),

    new Post(3, "Hvilket �r blev FN grundlagt?", "Jens Larsen", 1, DateTime.Now.AddDays(-3),
        new List<Comment>
        {
            new Comment(1, "Viggo Verdensmand", "1945", 1, DateTime.Now, DateTime.Now),
            new Comment(2, "Svend Sagnkonge", "Jeg mener, det var i 1066, lige efter vikingetiden!", 1, DateTime.Now, DateTime.Now),
            new Comment(3, "B�rge Burgerelsker", "FN? Er det ikke navnet p� en ny burger fra min lokale grillbar?", 1, DateTime.Now, DateTime.Now),
            new Comment(4, "Palle Pessimist", "Det var helt sikkert sidste torsdag... eller m�ske i n�ste uge.", 1, DateTime.Now, DateTime.Now)
        }),

    new Post(4, "Hvad hedder den l�ngste flod i verden?", "Mette S�rensen", 1, DateTime.Now.AddDays(-4),
        new List<Comment>
        {
            new Comment(1, "Gert Geograf", "Nilen", 1, DateTime.Now, DateTime.Now),
            new Comment(2, "Vibeke Vandl�b", "Mississippi! Fordi jeg kan stave til det!", 1, DateTime.Now, DateTime.Now),
            new Comment(3, "Holger Havevand", "M�ske den, der l�ber gennem vores have, n�r det regner?", 1, DateTime.Now, DateTime.Now),
            new Comment(4, "Frede Fragtmand", "Det m� v�re Amazon... den har jo 2-dages levering!", 1, DateTime.Now, DateTime.Now)
        }),

    new Post(5, "Hvem malede Mona Lisa?", "Peter Madsen", 1, DateTime.Now.AddDays(-5),
        new List<Comment>
        {
            new Comment(1, "Sofie Sk�nmager", "Leonardo da Vinci", 1, DateTime.Now, DateTime.Now),
            new Comment(2, "Ulla Udenfor", "Var det ikke Picasso, han har jo ogs� malet nogle sjove ansigter?", 1, DateTime.Now, DateTime.Now),
            new Comment(3, "Torben Tegnekunst", "Min nev�, da han var 4. Det ligner da lidt!", 1, DateTime.Now, DateTime.Now),
            new Comment(4, "Ingrid Instagram", "Jeg tror, det var Mona selv � selfie-style!", 1, DateTime.Now, DateTime.Now)
        }),


   new Post(6, "Hvad er den h�jeste bjergtop i verden?", "Sofie J�rgensen", 1, DateTime.Now.AddDays(-6),
        new List<Comment>
        {
            new Comment(1, "Benny Bjergbestiger", "Mount Everest", 1, DateTime.Now, DateTime.Now),
            new Comment(2, "Lars Lokalpatriot", "Ejer Bavneh�j � den har trods alt en god udsigt!", 1, DateTime.Now, DateTime.Now),
            new Comment(3, "Karl Kludder", "Himalaya? Eller var det Himalav?", 1, DateTime.Now, DateTime.Now),
            new Comment(4, "Helle Hverdag", "Det m� v�re min vasket�jskurv, den vokser konstant!", 1, DateTime.Now, DateTime.Now)
        }),

    new Post(7, "Hvilken planet er t�ttest p� solen?", "Anders Nielsen", 1, DateTime.Now.AddDays(-7),
        new List<Comment>
        {
            new Comment(1, "Niels Nysgerrig", "Merkur", 1, DateTime.Now, DateTime.Now),
            new Comment(2, "Greta Global", "Det m� v�re Jorden, for solen skinner altid lige her!", 1, DateTime.Now, DateTime.Now),
            new Comment(3, "S�ren Snacker", "Jeg g�tter p� Mars, de har jo chokoladebarer!", 1, DateTime.Now, DateTime.Now),
            new Comment(4, "Vibeke Vidtl�ftig", "Solen selv, den m� da v�re t�t p� sig selv!", 1, DateTime.Now, DateTime.Now)
        }),

    new Post(8, "Hvem skrev Hamlet?", "Niels Hansen", 1, DateTime.Now.AddDays(-8),
        new List<Comment>
        {
            new Comment(1, "Lis Litteratur", "William Shakespeare", 1, DateTime.Now, DateTime.Now),
            new Comment(2, "Arne Alfed", "Ham, der ogs� skrev Ringenes Herre, ikke?", 1, DateTime.Now, DateTime.Now),
            new Comment(3, "Poul Poet", "Det var Hamlet selv. Selvbiografi!", 1, DateTime.Now, DateTime.Now),
            new Comment(4, "Ella Elev", "Jeg tror, det var min gymnasiel�rer � hun elskede det i hvert fald!", 1, DateTime.Now, DateTime.Now)
        }),

    new Post(9, "Hvor mange kontinenter er der p� jorden?", "Lise Christiansen", 1, DateTime.Now.AddDays(-9),
        new List<Comment>
        {
            new Comment(1, "Troels T�ller", "7", 1, DateTime.Now, DateTime.Now),
            new Comment(2, "Svend Storskryder", "10 � jeg t�ller min kolonihave og parcelhuset med!", 1, DateTime.Now, DateTime.Now),
            new Comment(3, "Grethe G�r-det-selv", "Er IKEA et kontinent nu? De har jo alt!", 1, DateTime.Now, DateTime.Now),
            new Comment(4, "Bodil Br�delsker", "Kontinenter? Er det ikke noget man spiser til morgenmad?", 1, DateTime.Now, DateTime.Now)
        }),

    new Post(10, "Hvilken gas er den mest udbredte i Jordens atmosf�re?", "Erik Petersen", 1, DateTime.Now.AddDays(-10),
        new List<Comment>
        {
            new Comment(1, "Ole Oksygen", "Nitrogen", 1, DateTime.Now, DateTime.Now),
            new Comment(2, "Frede Fjolle", "Helium � fordi det er sjovt at snakke med!", 1, DateTime.Now, DateTime.Now),
            new Comment(3, "Vera Vognkender", "CO2 � det siger min bilmekaniker altid!", 1, DateTime.Now, DateTime.Now),
            new Comment(4, "Lars Luftig", "Luft, selvf�lgelig! Det er jo overalt!", 1, DateTime.Now, DateTime.Now)
        }),

      new Post(11, "Hvem opfandt telefonen?", "Kirsten Pedersen", 1, DateTime.Now.AddDays(-11),
        new List<Comment>
        {
            new Comment(1, "Peter Pioner", "Alexander Graham Bell", 1, DateTime.Now, DateTime.Now),
            new Comment(2, "Mette Mobil", "Det var helt sikkert Steve Jobs � han opfandt jo iPhone!", 1, DateTime.Now, DateTime.Now),
            new Comment(3, "Bodil Babler", "M�ske var det min far? Han er i hvert fald meget p� sin!", 1, DateTime.Now, DateTime.Now),
            new Comment(4, "Hans Humorist", "Jeg troede, det var den, der opfandt telefonfis!", 1, DateTime.Now, DateTime.Now)
        }),

    new Post(12, "Hvad er 2+2?", "Mads Jensen", 1, DateTime.Now.AddDays(-12),
        new List<Comment>
        {
            new Comment(1, "Rikke Regnemester", "4", 1, DateTime.Now, DateTime.Now),
            new Comment(2, "Svend Sk�vregner", "Det m� v�re 5, n�r jeg glemmer at t�lle rigtigt.", 1, DateTime.Now, DateTime.Now),
            new Comment(3, "Freja Filosof", "Hmm... Kan det ikke v�re lige, hvad man f�ler det som?", 1, DateTime.Now, DateTime.Now),
            new Comment(4, "Gert Genial", "Jeg siger 22 � fordi 2 ved siden af 2 ser s�dan ud!", 1, DateTime.Now, DateTime.Now)
        }),

    new Post(13, "Hvilket land er kendt som solens rige?", "Pia Hansen", 1, DateTime.Now.AddDays(-13),
        new List<Comment>
        {
            new Comment(1, "Ken Kyoto", "Japan", 1, DateTime.Now, DateTime.Now),
            new Comment(2, "Pedro Paella", "Spanien � de har da masser af sol!", 1, DateTime.Now, DateTime.Now),
            new Comment(3, "Bodil Badeg�st", "Jeg troede, det var Nordsj�lland om sommeren!", 1, DateTime.Now, DateTime.Now),
            new Comment(4, "Ali Aswan", "Egypten, fordi der er masser af sol og sand.", 1, DateTime.Now, DateTime.Now)
        }),

    new Post(14, "Hvad er verdens mindste land?", "Ole Mikkelsen", 1, DateTime.Now.AddDays(-14),
        new List<Comment>
        {
            new Comment(1, "Bente Bibelsk", "Vatikanstaten", 1, DateTime.Now, DateTime.Now),
            new Comment(2, "Carla Casino", "Monaco � der er knap nok plads til en strandstol!", 1, DateTime.Now, DateTime.Now),
            new Comment(3, "Henrik H�ndvask", "Mit badev�relse! Seri�st, det er et mikroland!", 1, DateTime.Now, DateTime.Now),
            new Comment(4, "Viggo Verdenslille", "Jeg siger Danmark, vi er jo ret sm�!", 1, DateTime.Now, DateTime.Now)
        }),

    new Post(15, "Hvilken farve har solen?", "Maria Petersen", 1, DateTime.Now.AddDays(-15),
        new List<Comment>
        {
            new Comment(1, "Astrid Astrolog", "Hvid", 1, DateTime.Now, DateTime.Now),
            new Comment(2, "Tina Tegner", "Gul � det ved enhver, der har tegnet en sol!", 1, DateTime.Now, DateTime.Now),
            new Comment(3, "Olav Orange", "Orange, ligesom min juice om morgenen!", 1, DateTime.Now, DateTime.Now),
            new Comment(4, "Rasmus Romantik", "Jeg har altid troet, den var r�d, n�r den g�r ned.", 1, DateTime.Now, DateTime.Now)
        }),

    new Post(16, "Hvem er kendt som kvantemekanikkens fader?", "Thomas Jensen", 1, DateTime.Now.AddDays(-16),
        new List<Comment>
        {
            new Comment(1, "Bj�rn Bohr", "Niels Bohr", 1, DateTime.Now, DateTime.Now),
            new Comment(2, "Erik E=mc2", "Det er nok Einstein, han opfandt jo alt smart!", 1, DateTime.Now, DateTime.Now),
            new Comment(3, "Henrik Heltefan", "Jeg har altid troet, det var Dr. Strange.", 1, DateTime.Now, DateTime.Now),
            new Comment(4, "Lone Lektor", "M�ske min gamle fysikl�rer, han troede i hvert fald, han vidste alt!", 1, DateTime.Now, DateTime.Now)
        }),

    new Post(17, "Hvilket dyr er kendt for at v�re det hurtigste p� landjorden?", "Lotte Nielsen", 1, DateTime.Now.AddDays(-17),
        new List<Comment>
        {
            new Comment(1, "Georg Gepard", "Gepard", 1, DateTime.Now, DateTime.Now),
            new Comment(2, "Frede Fartb�lle", "Jeg er ret sikker p�, at det er min nabo, n�r der er udsalg i Bilka!", 1, DateTime.Now, DateTime.Now),
            new Comment(3, "Olga Omvej", "Er det ikke en struds? De l�ber i hvert fald hurtigt fra problemer.", 1, DateTime.Now, DateTime.Now),
            new Comment(4, "Lars Lynet", "Det m� v�re Postmand Per, n�r han har travlt!", 1, DateTime.Now, DateTime.Now)
        }),

    new Post(18, "Hvilken planet er kendt som den r�de planet?", "Henrik Madsen", 1, DateTime.Now.AddDays(-18),
        new List<Comment>
        {
            new Comment(1, "Malte Marsmand", "Mars", 1, DateTime.Now, DateTime.Now),
            new Comment(2, "Venus Vera", "Venus? Fordi den lyser smukt om aftenen!", 1, DateTime.Now, DateTime.Now),
            new Comment(3, "Rikke Romantik", "Jeg troede, det var Jorden, n�r solen g�r ned.", 1, DateTime.Now, DateTime.Now),
            new Comment(4, "Tommy Tomat", "R�d planet? M�ske der, hvor tomaterne vokser!", 1, DateTime.Now, DateTime.Now)
        }),

    new Post(19, "Hvad er det kemiske symbol for vand?", "Mette Hansen", 1, DateTime.Now.AddDays(-19),
        new List<Comment>
        {
            new Comment(1, "Vandmand Viktor", "H2O", 1, DateTime.Now, DateTime.Now),
            new Comment(2, "Ella Emoji", "Er det ikke bare en bl� b�lge p� emojis?", 1, DateTime.Now, DateTime.Now),
            new Comment(3, "Bjarke Barbie", "Aqua! Ligesom bandet fra 90'erne!", 1, DateTime.Now, DateTime.Now),
            new Comment(4, "Niels Navngiver", "Jeg plejer bare at kalde det 'det v�de stof'.", 1, DateTime.Now, DateTime.Now)
        }),

    new Post(20, "Hvilket hav er det st�rste i verden?", "S�ren S�rensen", 1, DateTime.Now.AddDays(-20),
        new List<Comment>
        {
            new Comment(1, "Hav-Hans", "Stillehavet", 1, DateTime.Now, DateTime.Now),
            new Comment(2, "Kasper Koks", "Jeg troede, det var 'det sorte hul' i mit k�kkenvask!", 1, DateTime.Now, DateTime.Now),
            new Comment(3, "Bodil Brol�gger", "Er det ikke bare den store vandpyt udenfor mit hus?", 1, DateTime.Now, DateTime.Now),
            new Comment(4, "Vibeke Vesterhav", "Kan det v�re Vesterhavet? Det f�les i hvert fald stort nok, n�r man ser det!", 1, DateTime.Now, DateTime.Now)
        }),
       new Post(21, "Hvor mange knogler er der i den menneskelige krop?", "Erik Andersen", 1, DateTime.Now.AddDays(-21),
        new List<Comment>
        {
            new Comment(1, "Kurt Knogle", "206", 1, DateTime.Now, DateTime.Now),
            new Comment(2, "Benny B�je", "Jeg har kun �n stor knogle, n�r jeg danser!", 1, DateTime.Now, DateTime.Now),
            new Comment(3, "Grethe Gips", "Nok til at jeg kan kn�kke dem alle, n�r jeg pr�ver at st� p� ski!", 1, DateTime.Now, DateTime.Now),
            new Comment(4, "Holger Halvhjerne", "Jeg t�ller mindst 300, n�r jeg t�ller t�erne med to gange!", 1, DateTime.Now, DateTime.Now)
        }),

    new Post(22, "Hvem var den f�rste mand p� m�nen?", "Laura Petersen", 1, DateTime.Now.AddDays(-22),
        new List<Comment>
        {
            new Comment(1, "Niels Nattevandrer", "Neil Armstrong", 1, DateTime.Now, DateTime.Now),
            new Comment(2, "Ole Opfinder", "Var det ikke Buzz Lightyear? Han kom jo 'til uendelighed og videre'!", 1, DateTime.Now, DateTime.Now),
            new Comment(3, "Frede Fantast", "Min f�tter var der i g�r � han sagde, det var ret �de!", 1, DateTime.Now, DateTime.Now),
            new Comment(4, "Turid Turist", "Det m� have v�ret en meget modig turist!", 1, DateTime.Now, DateTime.Now)
        }),

    new Post(23, "Hvad er Jordens omkreds ved �kvator?", "Kristian Larsen", 1, DateTime.Now.AddDays(-23),
        new List<Comment>
        {
            new Comment(1, "Rasmus Rundt", "40.075 km", 1, DateTime.Now, DateTime.Now),
            new Comment(2, "Gurli G�ben", "Jeg tror, det er nok til en god lang g�tur.", 1, DateTime.Now, DateTime.Now),
            new Comment(3, "Benny Bredben", "Det afh�nger vel af, hvor store dine skridt er!", 1, DateTime.Now, DateTime.Now),
            new Comment(4, "Pedal Peter", "Den er nok lidt st�rre end min cykelrute til arbejde.", 1, DateTime.Now, DateTime.Now)
        }),

    new Post(24, "Hvilket �r blev Berlinmuren nedrevet?", "Pernille Hansen", 1, DateTime.Now.AddDays(-24),
        new List<Comment>
        {
            new Comment(1, "Willy Westberlin", "1989", 1, DateTime.Now, DateTime.Now),
            new Comment(2, "Hasse Hoffen", "Var det ikke, da David Hasselhoff sang 'Looking for Freedom'?", 1, DateTime.Now, DateTime.Now),
            new Comment(3, "Ole Optimist", "Jeg troede, de fjernede den for at f� plads til flere cykelstier!", 1, DateTime.Now, DateTime.Now),
            new Comment(4, "Hanne Historieforvirret", "Er den ikke stadig der? Jeg s� den i fjernsynet for nylig!", 1, DateTime.Now, DateTime.Now)
        }),

    new Post(25, "Hvad er det officielle sprog i Brasilien?", "Klaus Nielsen", 1, DateTime.Now.AddDays(-25),
        new List<Comment>
        {
            new Comment(1, "Pedro Portugues", "Portugisisk", 1, DateTime.Now, DateTime.Now),
            new Comment(2, "Signe Samba", "Er det ikke samba? Det lyder s�dan i hvert fald!", 1, DateTime.Now, DateTime.Now),
            new Comment(3, "Torben T�nker", "Brasiliansk, selvf�lgelig! Det er da indlysende!", 1, DateTime.Now, DateTime.Now),
            new Comment(4, "Dorte Danser", "Jeg troede, de bare talte i rytme og dansede?", 1, DateTime.Now, DateTime.Now)
        }),

    new Post(26, "Hvilken fiktiv detektiv bor p� 221B Baker Street?", "Anne Christensen", 1, DateTime.Now.AddDays(-26),
        new List<Comment>
        {
            new Comment(1, "Sigurd Skarp", "Sherlock Holmes", 1, DateTime.Now, DateTime.Now),
            new Comment(2, "Vera Vidtl�ftig", "Var det ikke Scooby-Doo? De l�ser jo ogs� mysterier!", 1, DateTime.Now, DateTime.Now),
            new Comment(3, "Bent Batmanfan", "M�ske det var Batman? Han virker ogs� som en, der bor i en fancy gade.", 1, DateTime.Now, DateTime.Now),
            new Comment(4, "Henning Hjemmebio", "Det m� v�re Mads Mikkelsen � han er jo med i alt nu om dage!", 1, DateTime.Now, DateTime.Now)
        }),

    new Post(27, "Hvilken gas bruges i elektriske p�rer?", "Nina Larsen", 1, DateTime.Now.AddDays(-27),
        new List<Comment>
        {
            new Comment(1, "Lars Lysmand", "Argon", 1, DateTime.Now, DateTime.Now),
            new Comment(2, "Flemming Flyver", "Helium, s� p�rerne ogs� kan sv�ve!", 1, DateTime.Now, DateTime.Now),
            new Comment(3, "Bodil Bl�ser", "Er det ikke luft? De virker, n�r jeg puster p� dem!", 1, DateTime.Now, DateTime.Now),
            new Comment(4, "Kaffe-Kurt", "Jeg troede, de fyldte dem med kaffe for at holde os v�gne!", 1, DateTime.Now, DateTime.Now)
        }),

    new Post(28, "Hvem var Cleopatra?", "Henning Madsen", 1, DateTime.Now.AddDays(-28),
        new List<Comment>
        {
            new Comment(1, "Nefertiti N�rd", "Dronning af Egypten", 1, DateTime.Now, DateTime.Now),
            new Comment(2, "Rasmus Romer", "Det var hende fra Asterix og Obelix, ikke?", 1, DateTime.Now, DateTime.Now),
            new Comment(3, "Torben Trist", "Min eksk�reste � hun opf�rte sig i hvert fald som en dronning!", 1, DateTime.Now, DateTime.Now),
            new Comment(4, "Helle Hollywood", "Jeg troede, hun var en ber�mt skuespiller!", 1, DateTime.Now, DateTime.Now)
        }),

    new Post(29, "Hvor mange planeter er der i vores solsystem?", "Sara Mortensen", 1, DateTime.Now.AddDays(-29),
        new List<Comment>
        {
            new Comment(1, "Astrid Astronaut", "8", 1, DateTime.Now, DateTime.Now),
            new Comment(2, "Pluto-Poul", "Jeg t�ller ogs� Pluto, s� det m� v�re 9!", 1, DateTime.Now, DateTime.Now),
            new Comment(3, "B�rge Besserwisser", "Hvis man t�ller alle de planeter, jeg har opdaget, s� 12!", 1, DateTime.Now, DateTime.Now),
            new Comment(4, "Egon Egocentrisk", "Er Jorden ogs� en planet? Jeg troede, det var centrum for det hele!", 1, DateTime.Now, DateTime.Now)
        }),

    new Post(30, "Hvad er navnet p� verdens st�rste �rken?", "Peter Johansen", 1, DateTime.Now.AddDays(-30),
        new List<Comment>
        {
            new Comment(1, "Sven Sandstorm", "Sahara", 1, DateTime.Now, DateTime.Now),
            new Comment(2, "Henrik Hungersn�d", "Det m� v�re mit k�leskab � der er aldrig noget at spise!", 1, DateTime.Now, DateTime.Now),
            new Comment(3, "Gunnar Gr�spl�ne", "Er det ikke den i vores baghave? Den bliver i hvert fald t�r om sommeren.", 1, DateTime.Now, DateTime.Now),
            new Comment(4, "Rasmus Ruskold", "Sibirien! Det er koldt, men det f�les som en �rken nogle gange.", 1, DateTime.Now, DateTime.Now)
        }),

    new Post(31, "Hvilket land er kendt som tulipanernes land?", "Ida Kristensen", 1, DateTime.Now.AddDays(-31),
        new List<Comment>
        {
            new Comment(1, "Hans Haveekspert", "Holland", 1, DateTime.Now, DateTime.Now),
            new Comment(2, "Bodil Blomsterglad", "Er det ikke Tivoli? Der er jo masser af blomster der!", 1, DateTime.Now, DateTime.Now),
            new Comment(3, "Kurt Koldt", "Jeg troede, det var Gr�nland � de har da blomster en gang om �ret!", 1, DateTime.Now, DateTime.Now),
            new Comment(4, "Svend Samleselv", "Kan det v�re IKEA? De s�lger i hvert fald mange planter!", 1, DateTime.Now, DateTime.Now)
        }),

    new Post(32, "Hvem skrev bogen '1984'?", "Simon Hansen", 1, DateTime.Now.AddDays(-32),
        new List<Comment>
        {
            new Comment(1, "Lone Litteraturfan", "George Orwell", 1, DateTime.Now, DateTime.Now),
            new Comment(2, "Viggo Vision�r", "Var det ikke Nostradamus? Han forudsagde vel alt!", 1, DateTime.Now, DateTime.Now),
            new Comment(3, "Edgar EDB", "Jeg troede, det var Bill Gates, han ved alt om computere!", 1, DateTime.Now, DateTime.Now),
            new Comment(4, "Frede Frygtelig", "M�ske var det min nabo � han er ret paranoid!", 1, DateTime.Now, DateTime.Now)
        }),

    new Post(33, "Hvad er den dybeste s� i verden?", "Karen Mikkelsen", 1, DateTime.Now.AddDays(-33),
        new List<Comment>
        {
            new Comment(1, "Bjarne Bajkal", "Bajkals�en", 1, DateTime.Now, DateTime.Now),
            new Comment(2, "Torben T�rer", "M�ske den s�, jeg drukner mine sorger i?", 1, DateTime.Now, DateTime.Now),
            new Comment(3, "Grethe Glemsom", "Er det ikke min vask, n�r jeg glemmer at slukke for vandet?", 1, DateTime.Now, DateTime.Now),
            new Comment(4, "Niels N�rig", "Jeg troede, det var min sparegris � den er i hvert fald dyb nok!", 1, DateTime.Now, DateTime.Now)
        }),

    new Post(34, "Hvilket metal bruges mest i elektronik?", "Lars Pedersen", 1, DateTime.Now.AddDays(-34),
        new List<Comment>
        {
            new Comment(1, "Karl Kabling", "Kobber", 1, DateTime.Now, DateTime.Now),
            new Comment(2, "Gert Guldgraver", "Er det ikke guld? Alt, hvad jeg k�ber, koster i hvert fald en formue!", 1, DateTime.Now, DateTime.Now),
            new Comment(3, "Bent Beholder", "Jeg troede, det var aluminium, s� vi kan folde vores fjernsyn sammen.", 1, DateTime.Now, DateTime.Now),
            new Comment(4, "Bodil Blikkenslager", "M�ske tin, for der er altid noget der siger 'tin' n�r det g�r i stykker!", 1, DateTime.Now, DateTime.Now)
        }),

    new Post(35, "Hvad er verdens h�jeste vandfald?", "Ole Madsen", 1, DateTime.Now.AddDays(-35),
        new List<Comment>
        {
            new Comment(1, "Villy Vandrer", "Angel Falls", 1, DateTime.Now, DateTime.Now),
            new Comment(2, "Hanne Hjemmevant", "Det m� v�re mit brusebad � det er i hvert fald h�jt nok!", 1, DateTime.Now, DateTime.Now),
            new Comment(3, "Henrik Haveslange", "Jeg troede, det var vandet fra min have, n�r naboen har vandslangen fremme!", 1, DateTime.Now, DateTime.Now),
            new Comment(4, "Bente Billedsk�n", "Kan det v�re Niagara? Der er i hvert fald mange turister!", 1, DateTime.Now, DateTime.Now)
        }),

    new Post(36, "Hvem var Napoleon Bonaparte?", "Jens Jensen", 1, DateTime.Now.AddDays(-36),
        new List<Comment>
        {
            new Comment(1, "Flemming Frankofil", "Fransk kejser", 1, DateTime.Now, DateTime.Now),
            new Comment(2, "Gitte Galocher", "Var han ikke bare en fyr, der bar en sjov hat?", 1, DateTime.Now, DateTime.Now),
            new Comment(3, "Benny Bagv�rk", "Jeg troede, det var en dessert. De serverer den p� mit lokale bageri!", 1, DateTime.Now, DateTime.Now),
            new Comment(4, "Svend Snapchat", "Han var vel en slags influencer for franske soldater!", 1, DateTime.Now, DateTime.Now)
        }),

    new Post(37, "Hvad hedder Sveriges hovedstad?", "Pernille Hansen", 1, DateTime.Now.AddDays(-37),
        new List<Comment>
        {
            new Comment(1, "Sten Svensson", "Stockholm", 1, DateTime.Now, DateTime.Now),
            new Comment(2, "Glenn G�tter", "G�teborg � det lyder da n�sten som hovedstaden, ikke?", 1, DateTime.Now, DateTime.Now),
            new Comment(3, "Olga Organiseret", "Jeg troede, det var Ikea City?", 1, DateTime.Now, DateTime.Now),
            new Comment(4, "Frede Fisker", "Det er nok bare der, hvor de laver mest surstr�mming!", 1, DateTime.Now, DateTime.Now)
        }),

    new Post(38, "Hvilken type blod kan modtages af alle?", "Katrine Nielsen", 1, DateTime.Now.AddDays(-38),
        new List<Comment>
        {
            new Comment(1, "Viggo Venepunkt", "Blodtype O", 1, DateTime.Now, DateTime.Now),
            new Comment(2, "Hanne Hydreret", "Det er da nok tomatjuice, det kan vi alle drikke!", 1, DateTime.Now, DateTime.Now),
            new Comment(3, "Bjarne Barrique", "Er det ikke r�dvin? Det virker i hvert fald til mange fester!", 1, DateTime.Now, DateTime.Now),
            new Comment(4, "Poul Positiv", "Jeg siger blodtype B, for det lyder da bedst!", 1, DateTime.Now, DateTime.Now)
        }),

    new Post(39, "Hvad er hovedstaden i Italien?", "Anders Johansen", 1, DateTime.Now.AddDays(-39),
        new List<Comment>
        {
            new Comment(1, "Ren� Romersk", "Rom", 1, DateTime.Now, DateTime.Now),
            new Comment(2, "Morten Mozzarella", "Pizza City, selvf�lgelig! De laver jo den bedste pizza!", 1, DateTime.Now, DateTime.Now),
            new Comment(3, "Gitte Gucci", "Er det ikke Milan? De har da de mest fashionable mennesker!", 1, DateTime.Now, DateTime.Now),
            new Comment(4, "Svend Sejler", "Jeg troede, det var Venedig � der er jo vand overalt!", 1, DateTime.Now, DateTime.Now)
        }),

    new Post(40, "Hvilket dyr er kendt for at have den l�ngste hals?", "Tina Mortensen", 1, DateTime.Now.AddDays(-40),
        new List<Comment>
        {
            new Comment(1, "Lars Langhals", "Giraf", 1, DateTime.Now, DateTime.Now),
            new Comment(2, "Bodil Blikkenslager", "Jeg tror, det er min nabo, n�r han str�kker sig for at se ind ad vores vindue!", 1, DateTime.Now, DateTime.Now),
            new Comment(3, "Grete G�s", "Er det ikke en svane? De har da en ret lang hals!", 1, DateTime.Now, DateTime.Now),
            new Comment(4, "Henrik H�je Hoved", "M�ske en dromedar � den har i hvert fald lange ben!", 1, DateTime.Now, DateTime.Now)
        }),

   new Post(41, "Hvem var den f�rste kvinde i rummet?", "Lise S�rensen", 1, DateTime.Now.AddDays(-41),
        new List<Comment>
        {
            new Comment(1, "Astrid Astrogirl", "Valentina Tereshkova", 1, DateTime.Now, DateTime.Now),
            new Comment(2, "Gunnar Gakket", "Var det ikke Lady Gaga? Hun virker i hvert fald rumagtig.", 1, DateTime.Now, DateTime.Now),
            new Comment(3, "Torben T�get", "M�ske min mor, hun sagde altid, hun var 'helt ude i rummet'.", 1, DateTime.Now, DateTime.Now),
            new Comment(4, "Niels N�gter", "Er det ikke bare en urban legende?", 1, DateTime.Now, DateTime.Now)
        }),

    new Post(42, "Hvad er verdens st�rste �?", "Kasper Andersen", 1, DateTime.Now.AddDays(-42),
        new List<Comment>
        {
            new Comment(1, "Gr�nlands-Georg", "Gr�nland", 1, DateTime.Now, DateTime.Now),
            new Comment(2, "Arne Australien", "Er det ikke Australien? De er jo ret store!", 1, DateTime.Now, DateTime.Now),
            new Comment(3, "Ib Indretter", "M�ske IKEA, de har jo alt i �n bygning!", 1, DateTime.Now, DateTime.Now),
            new Comment(4, "Frede Fritidselsker", "Jeg troede, det var min campingplads om sommeren.", 1, DateTime.Now, DateTime.Now)
        }),

    new Post(43, "Hvilket sprog taler man i Brasilien?", "Louise Mikkelsen", 1, DateTime.Now.AddDays(-43),
        new List<Comment>
        {
            new Comment(1, "Pedro Portugues", "Portugisisk", 1, DateTime.Now, DateTime.Now),
            new Comment(2, "Torben Trodsig", "Er det ikke brasiliansk? Det giver da mening!", 1, DateTime.Now, DateTime.Now),
            new Comment(3, "Rikke Rytmisk", "Jeg tror, de synger og danser det hele.", 1, DateTime.Now, DateTime.Now),
            new Comment(4, "Svend Spansk", "Jeg siger spansk � de er vel naboer!", 1, DateTime.Now, DateTime.Now)
        }),

    new Post(44, "Hvilket dyr kan skifte farve for at kamuflere sig?", "Emil Hansen", 1, DateTime.Now.AddDays(-44),
        new List<Comment>
        {
            new Comment(1, "Karsten Kam�leon", "Kam�leon", 1, DateTime.Now, DateTime.Now),
            new Comment(2, "Gitte Gnavpot", "Er det ikke min chef, han skifter altid holdning!", 1, DateTime.Now, DateTime.Now),
            new Comment(3, "Henrik Huskat", "M�ske det er katten � den forsvinder altid, n�r jeg skal finde den.", 1, DateTime.Now, DateTime.Now),
            new Comment(4, "Per Papsvinger", "Jeg troede, det var min teenage-s�n. Han skifter stil hver uge!", 1, DateTime.Now, DateTime.Now)
        }),

    new Post(45, "Hvad er navnet p� det t�tteste galakse til M�lkevejen?", "Anna Larsen", 1, DateTime.Now.AddDays(-45),
        new List<Comment>
        {
            new Comment(1, "Astrid Astronom", "Andromeda", 1, DateTime.Now, DateTime.Now),
            new Comment(2, "Morten Mars", "Er det ikke Mars? Den er jo ret t�t p�!", 1, DateTime.Now, DateTime.Now),
            new Comment(3, "S�ren Slikmund", "Jeg tror, det er Toms chokoladegalakse � den er t�t p� mig!", 1, DateTime.Now, DateTime.Now),
            new Comment(4, "Viggo Verdensmand", "Jeg siger Disneyland � det f�les som en anden verden.", 1, DateTime.Now, DateTime.Now)
        }),

    new Post(46, "Hvilket land er kendt for sit l�ftede Eiffelt�rn?", "S�ren Hansen", 1, DateTime.Now.AddDays(-46),
        new List<Comment>
        {
            new Comment(1, "Fran�ois Franskmand", "Frankrig", 1, DateTime.Now, DateTime.Now),
            new Comment(2, "Bruno Belgier", "Belgien � de er jo lige ved siden af, ikke?", 1, DateTime.Now, DateTime.Now),
            new Comment(3, "Frede Frihed", "Det er nok USA � de plejer at stj�le id�er!", 1, DateTime.Now, DateTime.Now),
            new Comment(4, "Vittorio Vildt", "Jeg troede, det var Italien, de har jo ogs� et sk�vt t�rn!", 1, DateTime.Now, DateTime.Now)
        }),

    new Post(47, "Hvem opfandt lysp�ren?", "Mads Pedersen", 1, DateTime.Now.AddDays(-47),
        new List<Comment>
        {
            new Comment(1, "Erik Elektriker", "Thomas Edison", 1, DateTime.Now, DateTime.Now),
            new Comment(2, "Bj�rn Braget", "Jeg troede, det var en tilf�ldig lynstorm!", 1, DateTime.Now, DateTime.Now),
            new Comment(3, "Villy V�knat", "Det m� v�re min nabo � hans hus er altid oplyst om natten.", 1, DateTime.Now, DateTime.Now),
            new Comment(4, "Niels N�rd", "Jeg siger Tesla, han lyser altid op i diskussioner!", 1, DateTime.Now, DateTime.Now)
        }),

    new Post(48, "Hvad er den st�rste havdyr i verden?", "Carsten Petersen", 1, DateTime.Now.AddDays(-48),
        new List<Comment>
        {
            new Comment(1, "Bente Bl�hval", "Bl�hval", 1, DateTime.Now, DateTime.Now),
            new Comment(2, "Henning Havdyb", "Jeg troede, det var Loch Ness-monsteret.", 1, DateTime.Now, DateTime.Now),
            new Comment(3, "Grethe Gransker", "Er det ikke Titanic? Det var ret stort i hvert fald.", 1, DateTime.Now, DateTime.Now),
            new Comment(4, "Poul Pral", "Jeg siger det er min svigerfars fiskestories � de vokser og vokser!", 1, DateTime.Now, DateTime.Now)
        }),

    new Post(49, "Hvilken gas giver drikkevarer deres fizz?", "Ole Jensen", 1, DateTime.Now.AddDays(-49),
        new List<Comment>
        {
            new Comment(1, "Karla Kemi", "Kuldioxid", 1, DateTime.Now, DateTime.Now),
            new Comment(2, "Frede Fabel", "Er det ikke bare magi? Det f�les i hvert fald s�dan!", 1, DateTime.Now, DateTime.Now),
            new Comment(3, "Viggo Vandsprut", "Mentos, n�r du putter dem i cola!", 1, DateTime.Now, DateTime.Now),
            new Comment(4, "Hans Helium", "Det m� v�re helium, s� vi alle kan tale sjovt bagefter!", 1, DateTime.Now, DateTime.Now)
        }),

    new Post(50, "Hvem var den f�rste pr�sident i USA?", "Camilla S�rensen", 1, DateTime.Now.AddDays(-50),
        new List<Comment>
        {
            new Comment(1, "S�ren Statsmand", "George Washington", 1, DateTime.Now, DateTime.Now),
            new Comment(2, "Preben Politisk", "Jeg tror, det var Donald Trump � han taler i hvert fald som om han var det!", 1, DateTime.Now, DateTime.Now),
            new Comment(3, "Bodil Barak", "Var det ikke Barack Obama? Han virker som den f�rste til alt!", 1, DateTime.Now, DateTime.Now),
            new Comment(4, "Henrik Historieglad", "M�ske det var min gamle historiel�rer? Han vidste alt om fortiden.", 1, DateTime.Now, DateTime.Now)
        })
};


// GET Hent alle tr�de
app.MapGet("/api/post", () => post);

// GET F� en specifik post
app.MapGet("/api/post/{id}", (int id) =>
{
    if (id < 0 || id >= post.Length)
    {
        return Results.BadRequest("Invalid post ID.");
    }

    var selectedPost = post[id];

    return Results.Ok(selectedPost);
});

//PUT giv tr�den en h�jere v�rdi
app.MapPut("/api/post/{id}/upvote", (int id, Post updatedPost) =>
{
    if (id < 0 || id >= post.Length)
    {
        return Results.BadRequest("Invalid index.");
    }

    var postToUpdate = post[id];
    var updatedValue = postToUpdate.value + 1;

   
    post[id] = updatedPost with { value = updatedValue };


    Console.WriteLine($"Updated post at index {id}: {updatedPost.value}");

    return Results.Ok(post);
});

// PUT Giv tr�den en lavere v�rdi
app.MapPut("/api/post/{id}/downvote", (int id, Post updatedPost) =>
{
    if (id < 0 || id >= post.Length)
    {
        return Results.BadRequest("Invalid index.");
    }

    
    var postToUpdate = post[id];
    var updatedValue = postToUpdate.value - 1;

    post[id] = updatedPost with { value = updatedValue };


    Console.WriteLine($"Updated post at index {id}: {updatedPost.value}");

    return Results.Ok(post);
});

// POST: Tilf�j en kommentar i en tr�d
app.MapPost("/api/posts/{postId}/comments", (long postId, Comment newComment) =>
{
    
    if (postId < 0 || postId >= post.Length)
    {
        return Results.BadRequest("Invalid post index.");
    }

   
    var postToUpdate = post[postId];

    
    var newCommentWithId = new Comment(
        postToUpdate.comments.Any() ? postToUpdate.comments.Max(c => c.CommentId) + 1 : 1,
        newComment.UserName,
        newComment.Text,
        newComment.Value,
        DateTime.Now,
        DateTime.Now
    );

    
    postToUpdate.comments.Add(newCommentWithId);

    
    Console.WriteLine($"Added new comment by {newComment.UserName} to post: {postToUpdate.name}");

   
    return Results.Ok(postToUpdate);
});


// PUT Giver en specifik kommentar en h�jere v�rdi
app.MapPut("/api/post/{postId}/comment/{commentId}/upvote", (int postId, int commentId) =>
{
    // Tjek for gyldigt postId
    if (postId < 0 || postId >= post.Length)
    {
        return Results.BadRequest("Invalid post index.");
    }

    var postToUpdate = post[postId];

   
    var commentToUpdate = postToUpdate.comments.SingleOrDefault(c => c.CommentId == commentId);
    if (commentToUpdate == null)
    {
        return Results.BadRequest("Comment not found.");
    }

    
    commentToUpdate.Value += 1;

    Console.WriteLine($"Upvoted comment with id {commentId}: New Value = {commentToUpdate.Value}");

    return Results.Ok(postToUpdate.comments);
});


// PUT Giver en specifik kommentar en lavere v�rdi
app.MapPut("/api/post/{postId}/comment/{commentId}/downvote", (int postId, int commentId) =>
{
    
    if (postId < 0 || postId >= post.Length)
    {
        return Results.BadRequest("Invalid post index.");
    }

    var postToUpdate = post[postId];

   
    var commentToUpdate = postToUpdate.comments.SingleOrDefault(c => c.CommentId == commentId);
    if (commentToUpdate == null)
    {
        return Results.BadRequest("Comment not found.");
    }

   
    commentToUpdate.Value -= 1;

    Console.WriteLine($"Downvoted comment with id {commentId}: New Value = {commentToUpdate.Value}");

    return Results.Ok(postToUpdate.comments);
});

// POST: Tilf�j en tr�d
app.MapPost("/api/posts", (Post newPost) =>
{

   
    var postList = post.ToList();

    postList.Add(newPost);

  
    post = postList.ToArray();

    
    Console.WriteLine($"Added new post: {newPost.name}");

    
    return Results.Ok(post);
});

app.Run();

//Record definitioner
record Comment(long CommentId, string UserName, string Text, int Value, DateTime CreatedAt1, DateTime UpdatedAt1)
{
    public int Value { get; set; }
}
record Post(long PostId, string name, string Text, int value, DateTime CreatedAt, List<Comment> comments)
{
    
}