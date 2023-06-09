using Contractor.ViewModel;
using System.Diagnostics;

namespace Contractor.Components;

public partial class RoundProgressBar : ContentView
{
	private RoundProgressBarViewModel vM;

	public RoundProgressBar()
	{
		InitializeComponent();
	}

    protected override void OnBindingContextChanged()
    {
        base.OnBindingContextChanged();

        vM = BindingContext as RoundProgressBarViewModel;

        try
        {
            vM.PropertyChanged += (s, m) => redrawGraphicsView();
        }
        catch (Exception ex)
        {
            Trace.Write(ex.ToString());
        }
    }

    private void redrawGraphicsView()
    {
		test.Invalidate();
    }
}