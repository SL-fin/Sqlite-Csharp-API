using Sqlite_Csharp;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

var DB = new PetsDB();

app.MapPost("/Omistajat", (Omistaja omistaja) =>
{
    DB.LisaaOmistaja(omistaja.Id, omistaja.Nimi, omistaja.Puhelin);
    return "omistaja lisätty!";
});

app.MapPost("/Lemmikit", (Lemmikki lemmikki) =>
{
    DB.LisaaLemmikki(lemmikki.Id, lemmikki.Nimi, lemmikki.Laji, lemmikki.Omistajan_id);
    return "lemmikki lisätty!";
});

app.MapGet("/lemmikit/{nimi}", (string nimi) =>
{
    string numero = DB.EtsiNumero(nimi);
    return $"Omistajan numero: {numero}";
});

app.Run();

public class Omistaja
{
    public int Id { get; set; }
    public string? Nimi { get; set; }
    public string? Puhelin { get; set; }
}

public class Lemmikki
{
    public int Id { get; set; }
    public string? Nimi { get; set; }
    public string? Laji { get; set; }
    public int Omistajan_id { get; set; }
}