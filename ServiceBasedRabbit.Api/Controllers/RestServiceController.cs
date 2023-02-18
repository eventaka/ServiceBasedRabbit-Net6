//using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceBasedRabbit.Core.Dto;
using ServiceBasedRabbit.Core.Interfaces;
using ServiceBasedRabbit.Core.Interfaces.MessageBroker;
using System;
using System.Threading.Tasks;

namespace ServiceBasedRabbit.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RestServiceController : ControllerBase
    {

        //private readonly IAddUserItem _addUserItem;
        //private readonly IDeleteUserItem _deleteUserItem;
        //private readonly IGetUserItem _getUserItem;
        private readonly IRabbitMQPublisher _publisherMessage;

       // private readonly IMediator _mediator;

        public RestServiceController(IRabbitMQPublisher publisherMessage)
        {
            //_addUserItem = addUserItem;
            //_deleteUserItem = deleteUserItem;
            //_getUserItem = getUserItem;
            _publisherMessage = publisherMessage;

            //_mediator = mediator;

        }




        /// <summary>
        /// Create User
        /// </summary>
        /// <param name="userdto"></param>
        /// <returns></returns>
        [HttpPost("AddUser")]
        public async Task<IActionResult> CreateUserAsync([FromBody] UserDto userdto)
        {


            try
            {
        
                _publisherMessage.Publish(userdto, "user_queue", "user.create"); //,"report.order",null); // routing..

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ($"Exception:{ex}"));
            }

        }





        /// <summary>
        /// Create Item 
        /// </summary>
        /// <param name="itemdto"></param>
        /// <returns></returns>
        [HttpPost("AddItem")]
        public async Task<IActionResult> CreateItemAsync([FromBody] ItemDto itemdto)
        {


            try
            {

                _publisherMessage.Publish(itemdto, "item_queue", "item.create"); 

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ($"Exception:{ex}"));
            }

        }




        /// <summary>
        /// Add Item for a User
        /// </summary>
        /// <param name="userItemDto"></param>
        /// <returns></returns>
        [HttpPost("AddUserItem")]
        public async Task<IActionResult> PostUserItemAsync([FromBody] UserItemDto userItemDto)
        {


            try
            {
                // Validation
                 _publisherMessage.Publish(userItemDto, "userItem_queue", "userItem.create"); //,"report.order",null); // routing..


                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ($"Exception:{ex}"));
            }

        }





        /// <summary>
        /// Delete Softly Item of a User
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("DeleteUserItem/{id}")]
        public async Task<IActionResult> DeleteUserItemAsync(int id)
        {


            try
            {

                // Validation
                _publisherMessage.Publish(id, "userItem_queue", "userItem.delete"); //,"report.order",null); // routing..


                return Ok();

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ($"Exception:{ex}"));
            }
        }
    }
}
