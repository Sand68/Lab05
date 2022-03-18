using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Lab05.Data;
using Lab05.Models;
using Azure.Storage.Blobs;

namespace Lab05.Pages.AnswerImages
{
    public class DeleteModel : PageModel
    {
        private readonly Lab05.Data.AnswerImageDataContext _context;
        private readonly BlobServiceClient _blobServiceClient;
        private readonly string earthContainerName = "earthimages";
        private readonly string computerContainerName = "computerimages";

        public DeleteModel(Lab05.Data.AnswerImageDataContext context, BlobServiceClient blobServiceClient)
        {
            _context = context;
            _blobServiceClient = blobServiceClient;
        }

        [BindProperty]
        public AnswerImage AnswerImage { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            AnswerImage = await _context.AnswerImages.FirstOrDefaultAsync(m => m.AnswerImageId == id);

            if (AnswerImage == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            AnswerImage = await _context.AnswerImages.FindAsync(id);

            if (AnswerImage != null)
            {
                _context.AnswerImages.Remove(AnswerImage);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
