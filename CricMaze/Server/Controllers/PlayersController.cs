using CricMaze.Server.Models;
using CricMaze.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CricMaze.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayersController : ControllerBase
    {
        private readonly IPlayerRepository playerRepository;

        public PlayersController(IPlayerRepository playerRepository)
        {
            this.playerRepository = playerRepository;
        }

        [HttpGet]
        public async Task<ActionResult> GetPlayers(int skip = 0, int take = 5, string orderBy = "PlayerId")
        {
            try
            {
                return Ok(await playerRepository.GetPlayers(skip,take,orderBy));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Player>> GetPlayer(int id)
        {
            try
            {
                var result = await playerRepository.GetPlayer(id);

                if (result == null)
                {
                    return NotFound();
                }

                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }


        [HttpGet("all")]
        public async Task<ActionResult> GetAllPlayers()
        {

            try
            {
                return Ok(await playerRepository.GetAllPlayers());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }



        [HttpPost]
        public async Task<ActionResult<Player>> CreatePlayer(Player player)
        {
            try
            {
                if (player == null)
                    return BadRequest();


                var createdPlayer = await playerRepository.AddPlayer(player);

                return CreatedAtAction(nameof(GetPlayer),
                    new { id = createdPlayer.PlayerId }, createdPlayer);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error creating new player record");
            }
        }


        [HttpPut("{id:int}")]
        public async Task<ActionResult<Player>> UpdatePlayer(int id, Player player)
        {
            try
            {
                if (id != player.PlayerId)
                    return BadRequest("Player ID mismatch");

                var playerToUpdate = await playerRepository.GetPlayer(id);

                if (playerToUpdate == null)
                {
                    return NotFound($"Player with Id = {id} not found");
                }

                return await playerRepository.UpdatePlayer(player);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error updating player record");
            }
        }


        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeletePlayer(int id)
        {
            try
            {
                var playerToDelete = await playerRepository.GetPlayer(id);

                if (playerToDelete == null)
                {
                    return NotFound($"Player with Id = {id} not found");
                }

                await playerRepository.DeletePlayer(id);

                return Ok($"Player with Id = {id} deleted");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error deleting player record");
            }
        }



        [HttpGet("{search}")]
        public async Task<ActionResult<IEnumerable<Player>>> Search(string name, Role? role)
        {
            try
            {
                var result = await playerRepository.Search(name, role);

                if (result.Any())
                {
                    return Ok(result);
                }

                return NotFound();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                "Error retrieving data from the database");
            }
        }
    }
}
