namespace PixelFit.Models.Training
{
    public class ProgramDayViewModel
    {
        public int Id { get; set; }

        public string DayName { get; set; } =
            string.Empty;

        public List<ProgramExerciseViewModel> Exercises { get; set; } =
            new();
    }
}