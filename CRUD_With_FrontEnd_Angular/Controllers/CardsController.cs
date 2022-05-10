using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CRUD_With_FrontEnd_Angular.Data;
using Microsoft.EntityFrameworkCore;
using CRUD_With_FrontEnd_Angular.Models;

namespace CRUD_With_FrontEnd_Angular.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class CardsController : Controller
    {

        public readonly CardsDbContext cardsDbContext;

        public CardsController(CardsDbContext cardsDbContext)
        {
            this.cardsDbContext = cardsDbContext;
        }

        /// <summary>
        /// Obtinem toate cardurile
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAllCards()
        {
            var cards = await cardsDbContext.Cards.ToListAsync();
            return Ok(cards);
        }

        /// <summary>
        /// Obtinem un singur card
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("{id:guid}")]
        [ActionName("GetCard")]
        public async Task<IActionResult> GetCard([FromRoute] Guid id)
        {
            var card = await cardsDbContext.Cards.FirstOrDefaultAsync(x => x.Id == id);
            if (card != null)
            {
                return Ok(card);
            }
            return NotFound("Cardul nu a fost identificat");
        }


        /// <summary>
        /// Adauga un card
        /// </summary>
        /// <param name="card"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> AddCard([FromBody] Card card)
        {
            card.Id = Guid.NewGuid();

            await cardsDbContext.Cards.AddAsync(card);
            await cardsDbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCard), new { id = card.Id}, card);
        }

        /// <summary>
        /// actualizeaza card
        /// </summary>
        /// <param name="id"></param>
        /// <param name="card"></param>
        /// <returns></returns>
        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateCard([FromRoute] Guid id, [FromBody] Card card)
        {
            var existingCard = await cardsDbContext.Cards.FirstOrDefaultAsync(x => x.Id == id);
            if (existingCard != null)
            {
                existingCard.CardNumber = card.CardNumber;
                existingCard.Proprietar_Card = card.Proprietar_Card;
                existingCard.Anul_expirarii = card.Anul_expirarii;
                existingCard.Luna_expirarii = card.Luna_expirarii;
                existingCard.CVV_code = card.CVV_code;
                await cardsDbContext.SaveChangesAsync();
                return Ok(existingCard);
            }
            return NotFound("Cardul nu a fost identificat");
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> UDeleteCard([FromRoute] Guid id, [FromBody] Card card)
        {
            var existingCard = await cardsDbContext.Cards.FirstOrDefaultAsync(x => x.Id == id);
            if (existingCard != null)
            {
                cardsDbContext.Remove(existingCard);
                await cardsDbContext.SaveChangesAsync();
                return Ok(existingCard);
            }
            return NotFound("Cardul nu a fost identificat");
        }
    }
}
