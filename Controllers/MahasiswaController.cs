using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System;

namespace tpmodul10_103022300061.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MahasiswaController : ControllerBase
    {
        private static List<Mahasiswa> mahasiswaList = new List<Mahasiswa>
        {
            new Mahasiswa ("Rafa Mufid 'Aqila", "103022300061"),
            new Mahasiswa ("Muhammad Thoriq Marcello", "103022300031"),
            new Mahasiswa ("Ahmad Dillan Ramadhan", "103022300037"),
            new Mahasiswa ("Muhammad Zaky Amarullah", "103022300045"),
            new Mahasiswa ("Muhammad Reza Ferdinal", "103022300135")
        };

        // GET /api/mahasiswa
        [HttpGet]
        public ActionResult<IEnumerable<Mahasiswa>> GetMahasiswa()
        {
            return Ok(mahasiswaList);
        }

        // GET /api/mahasiswa/{index}
        [HttpGet("{index}")]
        public ActionResult<Mahasiswa> GetMahasiswaByIndex(int index)
        {
            if (index < 0 || index >= mahasiswaList.Count)
            {
                return NotFound("Mahasiswa tidak ditemukan.");
            }
            return Ok(mahasiswaList[index]);
        }

        // POST /api/mahasiswa
        [HttpPost]
        public ActionResult PostMahasiswa([FromBody] Mahasiswa mahasiswa)
        {
            if (mahasiswa == null || string.IsNullOrEmpty(mahasiswa.nama) || string.IsNullOrEmpty(mahasiswa.nim))
            {
                return BadRequest("Nama dan NIM tidak boleh kosong.");
            }

            mahasiswaList.Add(mahasiswa);
            return CreatedAtAction(nameof(GetMahasiswa), new { id = mahasiswaList.Count - 1 }, mahasiswa);
        }

        // DELETE /api/mahasiswa/{index}
        [HttpDelete("{index}")]
        public ActionResult DeleteMahasiswa(int index)
        {
            if (index < 0 || index >= mahasiswaList.Count)
            {
                return NotFound("Mahasiswa tidak ditemukan.");
            }

            mahasiswaList.RemoveAt(index);
            return NoContent();
        }
    }
}
