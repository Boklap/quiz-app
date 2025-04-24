using MongoDB.Bson;

namespace QuizResultService.Domain.ValueObjects.QuizResult;

public class Quiz
{
    public string Id { get; set; }
    public string Difficulty { get; set; }
	public string Status { get; set; }
	public string Tag { get; set; }
	public string Name { get; set; }
	public string Description	{ get; set; }
	public int MinimumGrade { get; set; }
	public int TestDuration { get; set; }
	public int TotalQuestion { get; set; }

	public Quiz()
	{
	}

	public Quiz(
		string id,
		string difficulty,
		string status,
		string tag,
		string name,
		string description,
		int minimumGrade,
		int testDuration,
		int totalQuestion)
	{
		Id = id;
		Difficulty = difficulty;
		Status = status;
		Tag = tag;
		Name = name;
		Description = description;
		MinimumGrade = minimumGrade;
		TestDuration = testDuration;
		TotalQuestion = totalQuestion;
	}
}