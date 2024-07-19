namespace PokeroleBuddyClasses;

public partial class CustomCounter : ContentView
{
    private int _currentNumber = 0;

    public CustomCounter()
    {
        InitializeComponent();
        UpdateNumberLabel();
    }

    private void OnIncrementClicked(object sender, EventArgs e)
    {
        _currentNumber++;
        UpdateNumberLabel();
    }

    private void OnDecrementClicked(object sender, EventArgs e)
    {
        _currentNumber--;
        UpdateNumberLabel();
    }

    private void UpdateNumberLabel()
    {
        NumberLabel.Text = _currentNumber.ToString();
    }

    public void SetNumber(int number)
    {
        _currentNumber = number;
        UpdateNumberLabel();
    }

    public int GetNumber()
    {
        return _currentNumber;
    }
}