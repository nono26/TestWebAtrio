using part2.Models;
public interface IPersonneHandler
{
    Task<bool> AddPersonne(Personne personne);
    IEnumerable<GetPersonnesDto> GetPersonnes();
}