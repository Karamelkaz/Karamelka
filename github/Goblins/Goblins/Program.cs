using Microsoft.AspNetCore.Http;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
List<Goblins> repo =
[
    new(1,"����","167","16","�����"),
    new(2,"����","170","19","���"),
    new(3,"����","140","25","�����"),
    new(4,"����","189","23","�����")

];
app.MapGet("/", () => repo);
app.MapGet("/create", ([AsParameters] Goblins o) => repo.Add(o));
app.MapPut("/{number}", (int number, goblinsDTO dto) =>
{
    Goblins buffer = repo.Find(o => o.Number == number);
    if (buffer == null)
    
        return Results.NotFound("������ ������� ���");
        buffer.Name = dto.name;
        buffer.Height = dto.height;
        buffer.Age = dto.age;
        buffer.Weapon = dto.weapon;
    return Results.Json(buffer);
    
});
app.MapDelete("/", () => repo);
app.Run();

record class goblinsDTO(string name, string height, string age, string weapon);


class Goblins
{
    int number;
    string name;
    string height;
    string age;
    string weapon;


    public Goblins(int number, string name, string height, string age, string weapon)
    {
        Number = number;
        Name = name;
        Height = height;
        Age = age;
        Weapon = weapon;
    }


    public int Number { get => number; set => number = value; }
    public string Name { get => name; set => name = value; }
    public string Height { get => height; set => height = value; }
    public string Age { get => age; set => age = value; }
    public string Weapon { get => weapon; set => weapon = value; }
}