using ChainOfResponsibility.Problem.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChainOfResponsibility.Problem.Services
{
    public static class BannedWordsService
    {
        private static readonly List<string> BannedWords =
        [
            "burro",
            "burra",
            "idiota",
            "retardado",
            "retardada",
            "imbecil",
            "babaca",
            "otario",
            "otaria",
            "trouxa",
            "lerdo",
            "lerda",
            "fracassado",
            "fracassada",
            "estupido",
            "estupida",
            "anta",
            "mongol",
            "mongoloide",
            "maluco",
            "maluca"
            //... um sistema real seria mais complexo ou utilizaria inteligência artificial
        ];
        public static async Task<bool> ContainsBannedWord(string text)
        {
            await Task.Delay(50);
            return BannedWords.Any(x => text.Contains(x, StringComparison.InvariantCultureIgnoreCase));
        }
    }
}
