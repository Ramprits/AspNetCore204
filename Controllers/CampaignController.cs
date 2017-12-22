using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AspNetCoreApplication.Helper;
using AspNetCoreApplication.Model;
using AspNetCoreApplication.ModelDto;
using AspNetCoreApplication.Repository.Interface;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AspNetCoreApplication.Controllers {

    [Route ("api/campaign"), NoCache]
    public class CampaignController : Controller {
        private ICampaignRepository _repository;
        private readonly ILogger<CampaignController> _logger;
        private readonly IMapper _mapper;

        public CampaignController (ICampaignRepository repository, ILogger<CampaignController> logger, IMapper mapper) {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get () {
            var getCampaign = await _repository.CampaignsAsync ();
            return Ok (_mapper.Map<IEnumerable<CampaignVm>> (getCampaign));
        }

        [HttpGet ("{CampaignId}", Name = "GetCampaign")]
        public async Task<IActionResult> Get (Guid CampaignId) {
            var getCampaign = await _repository.CampaignsAsync ();
            return Ok (_mapper.Map<CampaignVm> (getCampaign));
        }

        [HttpPost]
        public async Task<IActionResult> AddCampaign ([FromBody] CampaignForCreationDto campaign) {
            if (!ModelState.IsValid) {
                return BadRequest ();
            }
            var newCampaign = _mapper.Map<Campaign> (campaign);
            await _repository.InsertCampaignAsync (newCampaign);
            if (!await _repository.SaveCampaignAsync ()) {
                return BadRequest ($"Unable to create campaign");
            }
            var campaignToReturn = _mapper.Map<CampaignVm> (newCampaign);
            return CreatedAtRoute ("GetCampaign", new { campaignId = campaignToReturn.CampaignId }, campaignToReturn);
        }
    }
}