﻿using System;
using System.Collections.Generic;
using System.Text;

namespace LawFirmBusinessLogic.HelperModels
{
    public class WordParagraph
    {
        public List<(string, WordTextProperties)> Texts { get; set; }
        public WordTextProperties TextProperties { get; set; }
    }
}
