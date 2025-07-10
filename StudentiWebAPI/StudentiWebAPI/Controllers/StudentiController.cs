using Microsoft.AspNetCore.Mvc;

namespace StudentiWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentiController : ControllerBase
    {
        static List<Studente> elenco = new List<Studente>() {
            new Studente(){Matricola=12345,Nome="Pietro",Cognome="De Lillo", Email="pietro.delillo@its.net", Classe="Cloud Specialist"},
            new Studente(){Matricola=12350,Nome="Laura",Cognome="De Paoli", Email="laura.depaoli@its.net", Classe="Cloud Specialist"},
            new Studente(){Matricola=12121,Nome="Giulia",Cognome="De Carlo", Email="giulia.decarlo@its.net", Classe="Cloud Specialist"},
            new Studente(){Matricola=11123,Nome="Roberto",Cognome="Di Freud", Email="roberto.difreud@its.net", Classe="Cloud Specialist"},
            new Studente(){Matricola=10256,Nome="Andrea",Cognome="Di Leo", Email="andrea.dileo@its.net", Classe="Cloud Specialist"},
            new Studente(){Matricola=63192,Nome="Piero",Cognome="De Carta", Email="piero.decarta@its.net", Classe="Cloud Specialist"},
            new Studente(){Matricola=74192,Nome="Paolo",Cognome="De Pietra", Email="paolo.depietra@its.net", Classe="Cloud Specialist"},
            new Studente(){Matricola=08781,Nome="Pierino",Cognome="De Argilla", Email="pierino.deargilla@its.net", Classe="Software Developer"},
            new Studente(){Matricola=52712,Nome="Perro",Cognome="De Pasta", Email="perro.depasta@its.net", Classe="Web Developer"},
            new Studente(){Matricola=82904,Nome="Pippo",Cognome="De Sale", Email="pippo.desale@its.net", Classe="Digital Strategist"}
        };

        [HttpGet]
        public List<Studente> Get()
        {
            var studentiOrdinati = elenco.OrderBy(s => s.Matricola).ToList();
            return studentiOrdinati;
        }

        [HttpGet("matricola/{matricola}")]
        public ActionResult<Studente> GetStudente(int matricola)
        {
            var studente = elenco.Where(s => s.Matricola == matricola).FirstOrDefault();
            if(studente == null)
                return NotFound($"Matricola {matricola} non esistente");
            return Ok(studente);
        }

        [HttpGet("classe/{classe}")]
        public ActionResult<Studente> GetStudentexClasse(string classe)
        {
            var classeS = elenco.Where(s => s.Classe == classe);
            if (classeS == null)
                return NotFound($"Classe {classe} non esistente");
            return Ok(classeS);
        }
    }
}
