  class ffxivcraftmodel {

  public class Crafter {

    private String[] actions = Array.Empty < string > ();
    private string cls = "";
    private int craftsmanship;
    private int control;
    private int craftPoints;
    private int level;
    private bool specialist;

    public Crafter(String cls, int level, int craftsmanship, int control, int craftPoints, bool specialist, String[] actions) {

      this.cls = cls;
      this.craftsmanship = craftsmanship;
      this.control = control;
      this.craftPoints = craftPoints;
      this.level = level;
      this.specialist = specialist;

      if (actions == null) {
        this.actions = Array.Empty < string > ();
      } else {
        this.actions = actions;
      }

    }

  }

  public class Recipe {

    public int suggestedCraftsmanship;
    public int suggestedControl;
    public int baseLevel;
    public int level;
    public int difficulty;
    public int durability;
    public int startQuality;
    public int maxQuality;

    public Recipe(int baseLevel, int level, int difficulty, int durability, int startQuality, int maxQuality, int suggestedCraftsmanship, int suggestedControl) {
      this.baseLevel = baseLevel;
      this.level = level;
      this.difficulty = difficulty;
      this.durability = durability;
      this.startQuality = startQuality;
      this.maxQuality = maxQuality;
      this.suggestedCraftsmanship = suggestedCraftsmanship; //|| SuggestedCraftsmanship[this.level];
      this.suggestedControl = suggestedControl; //|| SuggestedControl[this.level];
    }

  }

  public class Synth {

    private string crafter;
    private Recipe recipe;
    private int maxTrickUses;
    private bool useConditions;
    private int reliabilityIndex;
    private int maxLength;

    //new Synth(myWeaver, initiatesSlops, maxTrickUses=1, useConditions=true);

    public Synth() {}

    public Synth(String crafter, int recipe, int maxTrickUses = 1, int reliabilityIndex = 0, Boolean useConditions = true, int maxLength = 0) {
      this.crafter = crafter;
      this.recipe = new Recipe(20, 74, 70, 0, 1053, 0, 0, 0);
      this.maxTrickUses = maxTrickUses;
      this.useConditions = useConditions;
      this.reliabilityIndex = reliabilityIndex;
      this.maxLength = maxLength;
    }

    public float LevelDifferenceFactors(String kind, int levelDiff) {

      float[] craftsmanship = { 0.8f, 0.82f, 0.84f, 0.86f, 0.88f, 0.90f, 0.92f, 0.94f, 0.96f, 0.98f, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1.05f, 1.1f, 1.15f, 1.2f, 1.25f, 1.27f, 1.29f, 1.31f, 1.33f, 1.35f, 1.37f, 1.39f, 1.41f, 1.43f, 1.45f, 1.46f, 1.47f, 1.48f, 1.49f, 1.5f };
      float[] control = { 0.8f, 0.82f, 0.84f, 0.86f, 0.88f, 0.90f, 0.92f, 0.94f, 0.96f, 0.98f, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1.05f, 1.1f, 1.15f, 1.2f, 1.25f, 1.27f, 1.29f, 1.31f, 1.33f, 1.35f, 1.37f, 1.39f, 1.41f, 1.43f, 1.45f, 1.46f, 1.47f, 1.48f, 1.49f, 1.5f };
                
      switch (kind) {
      case "craftsmanship":
        return craftsmanship[levelDiff];
      case "control":
        return control[levelDiff];
      default:
        return 0;
      }

    }

    public float getLevelDifferenceFactor(String kind, int levelDiff) {

      levelDiff += 30;

      if (levelDiff < 0) levelDiff = 0;
      else if (levelDiff > 50) levelDiff = 50;

      return LevelDifferenceFactors(kind, levelDiff);

    }

    public double calculateBaseProgressIncrease(int levelDifference, int craftsmanship) {
      float levelDifferenceFactor = getLevelDifferenceFactor("craftsmanship", levelDifference);
      return Math.Floor((levelDifferenceFactor * (0.21 * craftsmanship + 2) * (10000 + craftsmanship)) / (10000 + 22 /*this.recipe.suggestedCraftsmanship*/ ));
    }

    public double calculateBaseQualityIncrease(int levelDifference, int control) {
      float levelDifferenceFactor = getLevelDifferenceFactor("control", levelDifference);
      return Math.Floor((levelDifferenceFactor * (0.35 * control + 35) * (10000 + control)) / (10000 + 11 /*this.recipe.suggestedControl*/ ));
    }

  }

}
