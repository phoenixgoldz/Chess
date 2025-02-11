using System;
using System.IO;

namespace SharpChess.Model
{
    public static class Game
    {
        public enum GameStageNames
        {
            Opening,
            Middle,
            End
        }
        
        public enum GameModes
        {
            Traditional,
            Chess960
        }

        public static GameModes SelectedGameMode = GameModes.Traditional;
        public static Player PlayerToPlay;
        public static Player PlayerWhite = new PlayerWhite();
        public static Player PlayerBlack = new PlayerBlack();
        public static int TurnNo;
        public static int MoveNo => TurnNo / 2;
        public static string FenStartPosition;
        public static Moves MoveHistory { get; private set; } = new Moves();
        public static int FiftyMoveDrawBase { get; private set; }
        public static int DifficultyLevel { get; set; }
        public static int ClockMaxMoves { get; set; }
        public static TimeSpan ClockTime { get; set; }
        public static bool UseRandomOpeningMoves { get; set; }
        public static int MaximumSearchDepth { get; set; }
        public static uint AvailableMegaBytes => 16;
        public static bool EnableTranspositionTable { get; set; }
        public static bool EnableHistoryHeuristic { get; set; }
        public static bool EnableKillerMoves { get; set; }
        public static bool EnableExtensions { get; set; }
        public static bool EnableNullMovePruning { get; set; }
        public static bool EnablePvsSearch { get; set; }
        public static bool EnableReductions { get; set; }
        public static bool EnableReductionFutilityMargin { get; set; }
        public static bool EnableReductionFutilityFixedDepth { get; set; }
        public static bool EnableReductionLateMove { get; set; }
        public static bool EnableAspiration { get; set; }
        public static bool EnableQuiescense { get; set; }
        public static bool CaptureMoveAnalysisData { get; set; }
        public static Moves MoveAnalysis { get; set; } = new Moves();
        public static bool EnablePondering { get; set; }
        public static TimeSpan ClockIncrementPerMove { get; set; }
        public static TimeSpan ClockFixedTimePerMove { get; set; }
        public static bool ShowThinking { get; set; }
        public static bool IsInAnalyseMode { get; set; }
        public static int MaxMaterialCount => 7;
        public static int LowestMaterialCount => Math.Min(PlayerWhite.MaterialCount, PlayerBlack.MaterialCount);
        public static GameStageNames Stage
        {
            get
            {
                if (LowestMaterialCount >= MaxMaterialCount)
                {
                    return GameStageNames.Opening;
                }
                return LowestMaterialCount <= 3 ? GameStageNames.End : GameStageNames.Middle;
            }
        }
        public static void Load(string filePath)
        {
            if (string.IsNullOrEmpty(filePath)) throw new ArgumentException("File path cannot be empty.");
            
            // Load game from file
            string fen = File.ReadAllText(filePath);
            FenStartPosition = fen;
            Board.SetPositionFromFen(fen);
            PlayerToPlay = (fen.Contains(" w ")) ? PlayerWhite : PlayerBlack;
        }

        public static void New(GameModes gameMode)
        {
            
            SelectedGameMode = gameMode;
            Board.Reset();
            
            if (gameMode == GameModes.Chess960)
            {
                Initialize();
            }
            else
            {
                Board.InitializeTraditional();
            }
        }
        

        public static void SuspendPondering() { }
        public static void ResumePondering() { }
        public static void CaptureAllPieces() { }
        public static void DemoteAllPieces() { }
        public static void PausePlay() { }
        public static void ResumePlay() { }
        public static void UndoMove(int moveCount = 1)
        {
            while (moveCount > 0 && MoveHistory.Count > 0)
            {
                Move lastMove = MoveHistory.Last();
                lastMove.Undo();
                MoveHistory.Remove(lastMove);
                TurnNo--;
                moveCount--;
            }
        }
        public static void MakeAMove(Move move, Piece piece, Square square)
        {
            if (piece == null || square == null) throw new ArgumentException("Invalid move parameters");
            
            if (!piece.CanMoveTo(square)) throw new InvalidOperationException("Invalid move");
            
            move.Execute();
            MoveHistory.Add(move);
            PlayerToPlay = (PlayerToPlay == PlayerWhite) ? PlayerBlack : PlayerWhite;
            TurnNo++;
        }
        public static void Initialize()
        {
            Board.SetupChess960Position();
        }
    }
}

