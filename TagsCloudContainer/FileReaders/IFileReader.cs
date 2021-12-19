﻿using System.Collections.Generic;

namespace TagsCloudContainer.FileReaders
{
    public interface IFileReader
    {
        HashSet<string> SupportedFormats { get; }
        Result<IEnumerable<string>> ReadWordsFromFile(string path);
    }
}