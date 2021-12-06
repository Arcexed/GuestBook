using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;
using GuestBook.Contracts.v1.Request;
using GuestBook.Contracts.v1.Response;
using GuestBook.Models;
using GuestBook.Options;
using Xunit;

namespace GuestBook.IntegrationTests
{
    public class NoteControllerTests : IntegrationTest
    {
        [Fact]
        public async Task GetAll_WithAnyNotesOrWithout_ReturnsList()
        {
            var response = await GetAllNotesAsync();
            var content = await response.Content.ReadAsStringAsync();
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            (await response.Content.ReadAsAsync<List<NoteResponse>>()).Should().BeOfType<List<NoteResponse>>();
        }
        [Fact]
        public async Task Get_ReturnsNote_WhenNoteExistsInDatabase()
        {
            var createdNoteResponse = await CreateNoteAsync(new CreateNoteRequest()
            {
                Name = "MyName",
                Email = "email@test.com",
                Text = "Text",
            });
            var getAllNotesResponse = await GetAllNotesAsync();

            createdNoteResponse.StatusCode.Should().Be(HttpStatusCode.OK);
            getAllNotesResponse.StatusCode.Should().Be(HttpStatusCode.OK);
            
            var createdNote = await createdNoteResponse.Content.ReadAsAsync<NoteResponse>();
            var returnedPostArray = (await getAllNotesResponse.Content.ReadAsAsync<List<NoteResponse>>());
            returnedPostArray.FirstOrDefault(d => d.Id == createdNote.Id)?.Id.Should().Be(createdNote.Id);
        }

        [Fact]
        public async Task Get_ReturnsNote_WhenNoteAddingWithoutSuccessFilteringName()
        {
            var createdNoteResponse = await CreateNoteAsync(new CreateNoteRequest()
            {
                Name = "My",
                Email = "email@test.com",
                Text = "Text",
            });
            createdNoteResponse.StatusCode.Should().Be(HttpStatusCode.BadRequest);
            var getAllNotesResponse = await GetAllNotesAsync();
            getAllNotesResponse.StatusCode.Should().Be(HttpStatusCode.OK);
            var createdNoteContent = await createdNoteResponse.Content.ReadAsStringAsync();
            createdNoteContent.Should()
                .Contain("The field Name must be a string or array type with a minimum length of '3'.");
        }

    }
}