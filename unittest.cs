using Xunit;
[Fact]
public void Vessel_Name_YearBuilt_Test()
{
    var vessel = new Vessel("Ship1", "2000");
    var name = vessel.GetName();
    var yearBuilt = vessel.GetYearBuilt();

    // Assert
    Assert.Equal("Ship1", name);
    Assert.Equal("2000", yearBuilt);
}

[Fact]
public void OldShipException_Test()
{
    var currentYear = DateTime.Now.Year;

    Assert.Throws<OldShipException>(() => new Vessel("OldShip", (currentYear - 21).ToString()));
}

[Fact]
public void Ferry_Passengers_Test()
{
    var ferry = new Ferry("Ferry1", "2012", 350);

    var passengers = ferry.Passengers;

    Assert.Equal(350, passengers);
}

[Fact]
public void Tugboat_MaxForce_Test()
{
    var tugboat = new Tugboat("Tugboat1", "2012", 800);

    var maxForce = tugboat.GetMaxForce();

    Assert.Equal(800, maxForce);
}

[Fact]
public void Submarine_MaxDepth_Test()
{
    var submarine = new Submarine("Submarine1", "2017", 500);

    var maxDepth = submarine.GetMaxDepth();

    Assert.Equal(500, maxDepth);
}

[Theory]
[InlineData(50, "51.44 KN")]
[InlineData(80, "59.72 KN")]
[InlineData(100, "98.68 KN")]
public void Speed_Format_Knots_Test(double speed, string expected)
{
    var speedClass = new Speed(speed);

    var result = speedClass.ToString("G", CultureInfo.InvariantCulture);

    Assert.Equal(expected, result);
}
[Theory]
[InlineData(50, "51.44 MS")]
[InlineData(80, "59.72 MS")]
[InlineData(100, "98.68 MS")]
public void Speed_Format_MetersPerSecond_Test(double speed, string expected)
{
    var speedClass = new Speed(speed);

    var result = speedClass.ToString("MS", CultureInfo.InvariantCulture);

    Assert.Equal(expected, result);
}
