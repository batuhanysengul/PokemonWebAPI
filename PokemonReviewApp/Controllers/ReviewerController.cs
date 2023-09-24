using Microsoft.AspNetCore.Mvc;
using PokemonReviewApp.Interfaces;
using PokemonReviewApp.Models;
using PokemonReviewApp.Repository;

namespace PokemonReviewApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewerController : Controller
    {
        private readonly IReviewerRepository _reviewerRepository;

        public ReviewerController(IReviewerRepository reviewerRepository)
        {
            _reviewerRepository = reviewerRepository;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Reviewer>))]
        public IActionResult GetReviewers()
        {
            var reviewers = _reviewerRepository.GetReviewers();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(reviewers);
        }

        [HttpGet("{reviewerId}")]
        [ProducesResponseType(200, Type = typeof(Reviewer))]
        [ProducesResponseType(400)]
        public IActionResult GetReviewer(int reviewerId)
        {
            if (!_reviewerRepository.ReviewerExists(reviewerId))
                return NotFound();

            var reviewer = _reviewerRepository.GetReviewer(reviewerId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(reviewer);
        }

        [HttpGet("{reviewerId}/reviews")]
        public IActionResult GetReviewsByAReviewer(int reviewerId)
        {
            if (!_reviewerRepository.ReviewerExists(reviewerId))
                return NotFound();
            
            var reviews = _reviewerRepository.GetReviewsByReviewer(reviewerId);

            if (!ModelState.IsValid)
                return NotFound();

            return Ok(reviews);
        }

    }
}
