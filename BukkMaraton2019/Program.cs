using BukkMaraton2019;
using BukkMaraton2019.Properties;

const int _indulok_szama = 691;
List<Versenyzo> versenyzok = new();

//3. feladat:
using StreamReader sr = new(@"..\..\..\Resources\bukkm2019.txt");
_ = sr.ReadLine();
while (!sr.EndOfStream)
    versenyzok.Add(new Versenyzo(sr.ReadLine()));

//4. feladat:
Console.WriteLine("4. feladat: " +
    "Versenytávot nem teljesítők aránya: " +
    $"{100 - (versenyzok.Count / (double)_indulok_szama * 100)}%");

//5. feladat:
int rttnvsz = versenyzok.Count(x => x.Tav == "Rövid" && !x.Nem);
Console.WriteLine("5. feladat: " +
    "Női versenyzők száma a rövid távú versenyen: " +
    $"{rttnvsz} fő");

//6. feladat:
bool vetm6otv = versenyzok.Any(x => x.Ido.TotalHours > 6);
Console.WriteLine("6. feladat: " +
    $"{(vetm6otv ? "Volt ilyen versenyző" : "Nem volt ilyen versenyző")}");

//7. feladat
Console.WriteLine("7. feladat: " +
    "A felnőtt férfi (ff) kategória győztese rövid távon: ");

Versenyzo rtffgy = versenyzok
    .Where(x => x.Kategoria == "ff" && x.Nem && x.Tav == "Rövid")
    .OrderBy(x => x.Ido)
    .First();

Console.WriteLine(
    $"\tRajtszám: {rtffgy.Rajtszam}\n" +
    $"\tNév: {rtffgy.Nev}\n" +
    $"{(string.IsNullOrWhiteSpace(rtffgy.Egyesulet) ? null : $"\tEgyesület: {rtffgy.Egyesulet}\n")}" +
    $"\tIdő: {rtffgy.Ido}");

//8. feladat:
Console.WriteLine("8. feladat: " +
    "Statisztika");
var fks = versenyzok.Where(x => x.Nem)
    .GroupBy(x => x.Kategoria);
foreach (var item in fks)
    Console.WriteLine($"\t{item.Key} - {item.Count()} fő");

    


