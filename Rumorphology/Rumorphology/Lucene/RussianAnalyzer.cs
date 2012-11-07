using System;
using System.Collections.Generic;
using System.IO;
using Lucene.Net.Analysis;
using Lucene.Net.Analysis.Ru;
using Rumorphology.OpenCorpora.DictionaryProcessor;
using Rumorphology.OpenCorpora.DictionaryReader;
using Version = Lucene.Net.Util.Version;

namespace Rumorphology.Lucene
{
    public class RussianAnalyzer : Analyzer
    {
        private readonly string _directoryLocation;

        private static readonly String[] RUSSIAN_STOP_WORDS = {
                                                                  "а", "без", "более", "бы", "был", "была", "были",
                                                                  "было", "быть", "в",
                                                                  "вам", "вас", "весь", "во", "вот", "все", "всего",
                                                                  "всех", "вы", "где",
                                                                  "да", "даже", "для", "до", "его", "ее", "ей", "ею",
                                                                  "если", "есть",
                                                                  "еще", "же", "за", "здесь", "и", "из", "или", "им",
                                                                  "их", "к", "как",
                                                                  "ко", "когда", "кто", "ли", "либо", "мне", "может",
                                                                  "мы", "на", "надо",
                                                                  "наш", "не", "него", "нее", "нет", "ни", "них", "но",
                                                                  "ну", "о", "об",
                                                                  "однако", "он", "она", "они", "оно", "от", "очень",
                                                                  "по", "под", "при",
                                                                  "с", "со", "так", "также", "такой", "там", "те", "тем"
                                                                  , "то", "того",
                                                                  "тоже", "той", "только", "том", "ты", "у", "уже",
                                                                  "хотя", "чего", "чей",
                                                                  "чем", "что", "чтобы", "чье", "чья", "эта", "эти",
                                                                  "это", "я"
                                                              };

        private readonly Version matchVersion;

        /// <summary>
        /// Contains the stopwords used with the StopFilter.
        /// </summary>
        private readonly ISet<string> stopSet;


        public RussianAnalyzer(Version matchVersion, string directoryLocation)
            : this(matchVersion, DefaultSetHolder.DEFAULT_STOP_SET)
        {
            _directoryLocation = directoryLocation;
        }

        /**
         * Builds an analyzer with the given stop words.
         * @deprecated use {@link #RussianAnalyzer(Version, Set)} instead
         */

        public RussianAnalyzer(Version matchVersion, params string[] stopwords)
            : this(matchVersion, StopFilter.MakeStopSet(stopwords))
        {
        }

        /**
         * Builds an analyzer with the given stop words
         * 
         * @param matchVersion
         *          lucene compatibility version
         * @param stopwords
         *          a stopword set
         */

        public RussianAnalyzer(Version matchVersion, ISet<string> stopwords)
        {
            stopSet = CharArraySet.UnmodifiableSet(CharArraySet.Copy(stopwords));
            this.matchVersion = matchVersion;
        }

        public override TokenStream TokenStream(string fieldName, TextReader reader)
        {
            var dictionaryReader = new DictionaryReader();
            var inMemoryWordsDictionary = new InMemoryWordsDictionary();
            dictionaryReader.ProcessDictionary(_directoryLocation,new List<IDictionaryProcessor>(){inMemoryWordsDictionary});
            TokenStream result = new RussianLetterTokenizer(reader);
            result = new LowerCaseFilter(result);
            result = new StopFilter(StopFilter.GetEnablePositionIncrementsVersionDefault(matchVersion),
                                    result, stopSet);
            result = new OpenCorporaRussianStemFilter(result, inMemoryWordsDictionary);
            return result;
        }

        #region Nested type: DefaultSetHolder

        private static class DefaultSetHolder
        {
            internal static readonly ISet<string> DEFAULT_STOP_SET =
                CharArraySet.UnmodifiableSet(new CharArraySet(RUSSIAN_STOP_WORDS, false));
        }

        #endregion
    }
}