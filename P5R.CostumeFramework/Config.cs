﻿using P5R.CostumeFramework.Characters;
using P5R.CostumeFramework.Template.Configuration;
using System.ComponentModel;

namespace P5R.CostumeFramework.Configuration;

public class Config : Configurable<Config>
{
    [DisplayName("Log Level")]
    [DefaultValue(LogLevel.Information)]
    public LogLevel LogLevel { get; set; } = LogLevel.Information;

    [DisplayName("Randomize Costumes")]
    [Description("Costume will randomize when moving between areas.")]
    [DefaultValue(false)]
    public bool RandomizeCostumes { get; set; } = false;

    [Category("Character Assets")]
    [DisplayName("Joker")]
    public CharacterAssets Joker_Assets { get; set; }

    [Category("Character Assets")]
    [DisplayName("Ryuji")]
    public CharacterAssets Ryuji_Assets { get; set; }

    [Category("Character Assets")]
    [DisplayName("Morgana")]
    public CharacterAssets Morgana_Assets { get; set; }

    [Category("Character Assets")]
    [DisplayName("Ann")]
    public CharacterAssets Ann_Assets { get; set; }

    [Category("Character Assets")]
    [DisplayName("Yusuke")]
    public CharacterAssets Yusuke_Assets { get; set; }

    [Category("Character Assets")]
    [DisplayName("Makoto")]
    public CharacterAssets Makoto_Assets { get; set; }

    [Category("Character Assets")]
    [DisplayName("Haru")]
    public CharacterAssets Haru_Assets { get; set; }

    [Category("Character Assets")]
    [DisplayName("Futaba")]
    public CharacterAssets Futaba_Assets { get; set; }

    [Category("Character Assets")]
    [DisplayName("Akechi")]
    public CharacterAssets Akechi_Assets { get; set; }

    [Category("Character Assets")]
    [DisplayName("Sumire")]
    public CharacterAssets Sumire_Assets { get; set; }

    [DisplayName("Overworld Costumes")]
    [Description("Costumes will apply in the overworld too.\nThis is just a for fun feature, expect some non-game breaking visual bugs.")]
    [DefaultValue(false)]
    public bool OverworldCostumes { get; set; } = false;

    [DisplayName("(Debug) Unlock All Items")]
    [DefaultValue(false)]
    public bool UnlockAllItems { get; set; } = false;
}

/// <summary>
/// Allows you to override certain aspects of the configuration creation process (e.g. create multiple configurations).
/// Override elements in <see cref="ConfiguratorMixinBase"/> for finer control.
/// </summary>
public class ConfiguratorMixin : ConfiguratorMixinBase
{
    // 
}