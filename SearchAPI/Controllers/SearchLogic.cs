﻿using System;
using System.Collections.Generic;

namespace SearchAPI.Controllers
{
    public class SearchLogic
    {
        Database mDatabase;

        Dictionary<string, int> mWords; 

        public SearchLogic(Database database)
        {
            mDatabase = database;
            var wordTask = mDatabase.GetAllWords();
            wordTask.Wait();
            mWords = wordTask.Result;
        }

        public int GetIdOf(string word)
        {
            if (mWords.ContainsKey(word))
                return mWords[word];
            return -1;
        }

        public async Task<List<KeyValuePair<int, int>>> GetDocuments(List<int> wordIds)
        {
            return await mDatabase.GetDocuments(wordIds);
        }

        public async Task<List<string>> GetDocumentDetails(List<int> docIds)
        {
            return await mDatabase.GetDocDetails(docIds);
        }
    }
}
