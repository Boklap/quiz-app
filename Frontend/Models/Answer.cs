using Microsoft.AspNetCore.Components.Forms;

namespace Frontend.Models;

public class Answer
{
    public string Text { get; set; } = "";
    public IBrowserFile? ImageFile { get; set; }
    public bool IsSelected { get; set; } = false;
}