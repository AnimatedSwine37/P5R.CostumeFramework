﻿using BGME.BattleThemes.Interfaces;
using BGME.Framework.Interfaces;
using P5R.CostumeFramework.Models;
using p5rpc.lib.interfaces;

namespace P5R.CostumeFramework.Costumes;

internal class CostumeMusicService
{
    private readonly IBgmeApi bgme;
    private readonly IBattleThemesApi battleThemes;
    private readonly IP5RLib p5rLib;
    private readonly CostumeRegistry costumes;

    private readonly Dictionary<Character, CostumeMusic> costumeMusic = new();

    public CostumeMusicService(
        IBgmeApi bgme,
        IBattleThemesApi battleThemes,
        IP5RLib p5rLib,
        CostumeRegistry costumes)
    {
        this.bgme = bgme;
        this.battleThemes = battleThemes;
        this.p5rLib = p5rLib;
        this.costumes = costumes;

        foreach (var character in Enum.GetValues<Character>())
        {
            this.costumeMusic[character] = new();
        }
    }

    public void Refresh()
    {
        foreach (var character in Enum.GetValues<Character>())
        {
            var outfitItemId = this.p5rLib.GET_EQUIP(character, EquipSlot.Costume);
            this.Refresh(outfitItemId);
        }
    }

    public void Refresh(int newOutfitItemId)
    {
        var costume = this.costumes.GetCostumeById(newOutfitItemId);
        if (costume == null)
        {
            return;
        }

        this.UpdateBgmeMusic(costume);
        this.UpdateBattleThemeMusic(costume);
    }

    private void UpdateBgmeMusic(Costume costume)
    {
        var currentBgmeFile = this.costumeMusic[costume.Character].MusicScriptFile;
        var newBgmeFile = costume.MusicScriptFile;

        // Costume music has changed.
        if (currentBgmeFile != newBgmeFile)
        {
            // Remove previous music, if any.
            if (currentBgmeFile != null)
            {
                this.bgme.RemovePath(currentBgmeFile);
                Log.Debug($"Costume music script removed: {costume.Character}");
            }

            // Add new costume music, if any.
            if (newBgmeFile != null)
            {
                this.bgme.AddPath(newBgmeFile);
                Log.Debug($"Costume music script added: {costume.Character} || {costume.GmdBindPath}");
            }
        }

        this.costumeMusic[costume.Character].MusicScriptFile = newBgmeFile;
    }

    private void UpdateBattleThemeMusic(Costume costume)
    {
        var currentThemeFile = this.costumeMusic[costume.Character].BattleThemeFile;
        var newThemeFile = costume.BattleThemeFile;

        // Costume music has changed.
        if (currentThemeFile != newThemeFile)
        {
            // Remove previous music, if any.
            if (currentThemeFile != null)
            {
                this.battleThemes.RemovePath(currentThemeFile);
                Log.Debug($"Costume battle theme removed: {costume.Character}");
            }

            // Add new costume music, if any.
            if (newThemeFile != null && costume.OwnerModId != null)
            {
                this.battleThemes.AddPath(costume.OwnerModId, newThemeFile);
                Log.Debug($"Costume battle theme added: {costume.Character} || {costume.GmdBindPath}");
            }
        }

        this.costumeMusic[costume.Character].BattleThemeFile = newThemeFile;
    }

    private class CostumeMusic
    {
        public string? MusicScriptFile { get; set; }

        public string? BattleThemeFile { get; set; }
    }
}
