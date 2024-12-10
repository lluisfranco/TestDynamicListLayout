using System.Data.SqlClient;

namespace TestDynamicListLayout.Data
{
    public class DbSeedService
    {
        public string ConnectionString { get; set; } = string.Empty;

        public async Task InsertRowsToDb(IEnumerable<AssetInfo> data)
        {
            foreach (var assetData in data)
            {
                await InsertToAssetData(assetData);
            }
        }

        public async Task InsertToAssetData(AssetInfo assetData)
        {
            var query = @"
                    INSERT INTO [dbo].[AssetData] (
                        [RowId], [AssetId], [AssetCode], [AssetName], [AssetTypeId], [AssetCurrencyId], [StatusId], [ISIN], [Ticker], [Comment], 
                        [CreatedUserName], [CreationDate], [ModifiedUserName], [ModifiedDate], [AssetIdGUID], [Managed], [ClosedDate], 
                        [ExclusivityIIC], [CashTypeId], [WatermarkInitialDate], [WatermarkInitialValue], [WatermarkReferredIndex], [BV_ItemId], 
                        [BV_1], [BV_28], [BV_46], [BV_56], [BV_57], [BV_58], [BV_59], [BV_60], [BV_61], [BV_62], [BV_63], [BV_65], [BV_66], 
                        [BV_67], [BV_68], [BV_69], [BV_70], [BV_72], [BV_77], [BV_85], [BV_86], [BV_87], [BV_88], [BV_90], [BV_93], [BV_94], 
                        [BV_95], [BV_97], [BV_98], [BV_99], [BV_105], [BV_106], [BV_163], [BV_170], [BV_171], [BV_172], [BV_173], [BV_175], 
                        [BV_176], [BV_177], [BV_178], [BV_180], [BV_181], [BV_184], [BV_186], [BV_187], [BV_188], [BV_189], [BV_192], [BV_194], 
                        [BV_195], [BV_200], [BV_201], [BV_202], [BV_203], [BV_204], [BV_245], [BV_249], [BV_254], [BV_255], [BV_256], [BV_257], 
                        [BV_258], [BV_259], [BV_260], [BV_261], [BV_262], [BV_263], [BV_265], [BV_271], [BV_272], [BV_273], [BV_274], [BV_275], 
                        [BV_276], [BV_277], [BV_278], [BV_279], [BV_280], [BV_281], [BV_282], [BV_283], [BV_284], [BV_285], [BV_287], [BV_288], 
                        [BV_289], [BV_290], [BV_291], [BV_300], [BV_301], [BV_302], [BV_303], [BV_304], [BV_305], [BV_306], [BV_307], [BV_308], 
                        [BV_309], [BV_310], [BV_311], [BV_312], [BV_313], [BV_314], [BV_315], [BV_316], [BV_317], [BV_318], [BV_319], [BV_321], 
                        [BV_1000002], [BV_1000013], [BV_1000025], [BV_1000028], [BV_1000031], [BV_1000032], [IsItemActive], [IsClass], [LastPrice], 
                        [LastPriceDate], [InitialAmountYTD], [FinalAmountYTD], [InOutYTD], [GainsYTD], [PerformanceYTD], [InitialDateYTD], 
                        [FinalDateYTD], [NumDaysYTD], [WeightedYTD], [InitialAmountD1], [FinalAmountD1], [InOutD1], [GainsD1], [PerformanceD1], 
                        [InitialDateD1], [FinalDateD1], [NumDaysD1], [WeightedD1], [InitialAmountMTD], [FinalAmountMTD], [InOutMTD], [GainsMTD], 
                        [PerformanceMTD], [InitialDateMTD], [FinalDateMTD], [NumDaysMTD], [WeightedMTD], [InitialAmountM12], [FinalAmountM12], 
                        [InOutM12], [GainsM12], [PerformanceM12], [InitialDateM12], [FinalDateM12], [NumDaysM12], [WeightedM12]
                    ) VALUES (
                        @RowId, @AssetId, @AssetCode, @AssetName, @AssetTypeId, @AssetCurrencyId, @StatusId, @ISIN, @Ticker, @Comment, 
                        @CreatedUserName, @CreationDate, @ModifiedUserName, @ModifiedDate, @AssetIdGUID, @Managed, @ClosedDate, 
                        @ExclusivityIIC, @CashTypeId, @WatermarkInitialDate, @WatermarkInitialValue, @WatermarkReferredIndex, @BV_ItemId, 
                        @BV_1, @BV_28, @BV_46, @BV_56, @BV_57, @BV_58, @BV_59, @BV_60, @BV_61, @BV_62, @BV_63, @BV_65, @BV_66, 
                        @BV_67, @BV_68, @BV_69, @BV_70, @BV_72, @BV_77, @BV_85, @BV_86, @BV_87, @BV_88, @BV_90, @BV_93, @BV_94, 
                        @BV_95, @BV_97, @BV_98, @BV_99, @BV_105, @BV_106, @BV_163, @BV_170, @BV_171, @BV_172, @BV_173, @BV_175, 
                        @BV_176, @BV_177, @BV_178, @BV_180, @BV_181, @BV_184, @BV_186, @BV_187, @BV_188, @BV_189, @BV_192, @BV_194, 
                        @BV_195, @BV_200, @BV_201, @BV_202, @BV_203, @BV_204, @BV_245, @BV_249, @BV_254, @BV_255, @BV_256, @BV_257, 
                        @BV_258, @BV_259, @BV_260, @BV_261, @BV_262, @BV_263, @BV_265, @BV_271, @BV_272, @BV_273, @BV_274, @BV_275, 
                        @BV_276, @BV_277, @BV_278, @BV_279, @BV_280, @BV_281, @BV_282, @BV_283, @BV_284, @BV_285, @BV_287, @BV_288, 
                        @BV_289, @BV_290, @BV_291, @BV_300, @BV_301, @BV_302, @BV_303, @BV_304, @BV_305, @BV_306, @BV_307, @BV_308, 
                        @BV_309, @BV_310, @BV_311, @BV_312, @BV_313, @BV_314, @BV_315, @BV_316, @BV_317, @BV_318, @BV_319, @BV_321, 
                        @BV_1000002, @BV_1000013, @BV_1000025, @BV_1000028, @BV_1000031, @BV_1000032, @IsItemActive, @IsClass, @LastPrice, 
                        @LastPriceDate, @InitialAmountYTD, @FinalAmountYTD, @InOutYTD, @GainsYTD, @PerformanceYTD, @InitialDateYTD, 
                        @FinalDateYTD, @NumDaysYTD, @WeightedYTD, @InitialAmountD1, @FinalAmountD1, @InOutD1, @GainsD1, @PerformanceD1, 
                        @InitialDateD1, @FinalDateD1, @NumDaysD1, @WeightedD1, @InitialAmountMTD, @FinalAmountMTD, @InOutMTD, @GainsMTD, 
                        @PerformanceMTD, @InitialDateMTD, @FinalDateMTD, @NumDaysMTD, @WeightedMTD, @InitialAmountM12, @FinalAmountM12, 
                        @InOutM12, @GainsM12, @PerformanceM12, @InitialDateM12, @FinalDateM12, @NumDaysM12, @WeightedM12
                    );
                ";

            using var connection = new SqlConnection(ConnectionString);
            connection.Open();
            using var command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@RowId", assetData.RowId);
            command.Parameters.AddWithValue("@AssetId", assetData.AssetId);
            command.Parameters.AddWithValue("@AssetCode", assetData.AssetCode);
            command.Parameters.AddWithValue("@AssetName", assetData.AssetName);
            command.Parameters.AddWithValue("@AssetTypeId", assetData.AssetTypeId);
            command.Parameters.AddWithValue("@AssetCurrencyId", assetData.AssetCurrencyId);
            command.Parameters.AddWithValue("@StatusId", assetData.StatusId);
            command.Parameters.AddWithValue("@ISIN", assetData.ISIN ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@Ticker", assetData.Ticker ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@Comment", assetData.Comment ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@CreatedUserName", assetData.CreatedUserName ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@CreationDate", assetData.CreationDate ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@ModifiedUserName", assetData.ModifiedUserName ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@ModifiedDate", assetData.ModifiedDate ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@AssetIdGUID", assetData.AssetIdGUID ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@Managed", assetData.Managed);
            command.Parameters.AddWithValue("@ClosedDate", assetData.ClosedDate ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@ExclusivityIIC", assetData.ExclusivityIIC ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@CashTypeId", assetData.CashTypeId ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@WatermarkInitialDate", assetData.WatermarkInitialDate ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@WatermarkInitialValue", assetData.WatermarkInitialValue ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@WatermarkReferredIndex", assetData.WatermarkReferredIndex ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@BV_ItemId", assetData.BV_ItemId);
            command.Parameters.AddWithValue("@BV_1", assetData.BV_1 ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@BV_28", assetData.BV_28 ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@BV_46", assetData.BV_46 ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@BV_56", assetData.BV_56 ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@BV_57", assetData.BV_57 ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@BV_58", assetData.BV_58 ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@BV_59", assetData.BV_59 ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@BV_60", assetData.BV_60 ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@BV_61", assetData.BV_61 ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@BV_62", assetData.BV_62 ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@BV_63", assetData.BV_63 ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@BV_65", assetData.BV_65 ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@BV_66", assetData.BV_66 ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@BV_67", assetData.BV_67 ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@BV_68", assetData.BV_68 ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@BV_69", assetData.BV_69 ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@BV_70", assetData.BV_70 ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@BV_72", assetData.BV_72 ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@BV_77", assetData.BV_77 ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@BV_85", assetData.BV_85 ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@BV_86", assetData.BV_86 ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@BV_87", assetData.BV_87 ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@BV_88", assetData.BV_88 ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@BV_90", assetData.BV_90 ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@BV_93", assetData.BV_93 ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@BV_94", assetData.BV_94 ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@BV_95", assetData.BV_95 ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@BV_97", assetData.BV_97 ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@BV_98", assetData.BV_98 ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@BV_99", assetData.BV_99 ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@BV_105", assetData.BV_105 ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@BV_106", assetData.BV_106 ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@BV_163", assetData.BV_163 ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@BV_170", assetData.BV_170 ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@BV_171", assetData.BV_171 ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@BV_172", assetData.BV_172 ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@BV_173", assetData.BV_173 ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@BV_175", assetData.BV_175 ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@BV_176", assetData.BV_176 ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@BV_177", assetData.BV_177 ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@BV_178", assetData.BV_178 ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@BV_180", assetData.BV_180 ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@BV_181", assetData.BV_181 ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@BV_184", assetData.BV_184 ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@BV_186", assetData.BV_186 ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@BV_187", assetData.BV_187 ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@BV_188", assetData.BV_188 ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@BV_189", assetData.BV_189 ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@BV_192", assetData.BV_192 ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@BV_194", assetData.BV_194 ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@BV_195", assetData.BV_195 ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@BV_200", assetData.BV_200 ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@BV_201", assetData.BV_201 ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@BV_202", assetData.BV_202 ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@BV_203", assetData.BV_203 ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@BV_204", assetData.BV_204 ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@BV_245", assetData.BV_245 ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@BV_249", assetData.BV_249 ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@BV_254", assetData.BV_254 ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@BV_255", assetData.BV_255 ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@BV_256", assetData.BV_256 ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@BV_257", assetData.BV_257 ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@BV_258", assetData.BV_258 ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@BV_259", assetData.BV_259 ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@BV_260", assetData.BV_260 ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@BV_261", assetData.BV_261 ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@BV_262", assetData.BV_262 ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@BV_263", assetData.BV_263 ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@BV_265", assetData.BV_265 ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@BV_271", assetData.BV_271 ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@BV_272", assetData.BV_272 ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@BV_273", assetData.BV_273 ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@BV_274", assetData.BV_274 ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@BV_275", assetData.BV_275 ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@BV_276", assetData.BV_276 ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@BV_277", assetData.BV_277 ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@BV_278", assetData.BV_278 ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@BV_279", assetData.BV_279 ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@BV_280", assetData.BV_280 ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@BV_281", assetData.BV_281 ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@BV_282", assetData.BV_282 ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@BV_283", assetData.BV_283 ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@BV_284", assetData.BV_284 ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@BV_285", assetData.BV_285 ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@BV_287", assetData.BV_287 ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@BV_288", assetData.BV_288 ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@BV_289", assetData.BV_289 ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@BV_290", assetData.BV_290 ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@BV_291", assetData.BV_291 ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@BV_300", assetData.BV_300 ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@BV_301", assetData.BV_301 ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@BV_302", assetData.BV_302 ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@BV_303", assetData.BV_303 ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@BV_304", assetData.BV_304 ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@BV_305", assetData.BV_305 ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@BV_306", assetData.BV_306 ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@BV_307", assetData.BV_307 ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@BV_308", assetData.BV_308 ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@BV_309", assetData.BV_309 ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@BV_310", assetData.BV_310 ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@BV_311", assetData.BV_311 ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@BV_312", assetData.BV_312 ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@BV_313", assetData.BV_313 ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@BV_314", assetData.BV_314 ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@BV_315", assetData.BV_315 ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@BV_316", assetData.BV_316 ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@BV_317", assetData.BV_317 ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@BV_318", assetData.BV_318 ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@BV_319", assetData.BV_319 ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@BV_321", assetData.BV_321 ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@BV_1000002", assetData.BV_1000002 ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@BV_1000013", assetData.BV_1000013 ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@BV_1000025", assetData.BV_1000025 ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@BV_1000028", assetData.BV_1000028 ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@BV_1000031", assetData.BV_1000031 ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@BV_1000032", assetData.BV_1000032 ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@IsItemActive", assetData.IsItemActive);
            command.Parameters.AddWithValue("@IsClass", assetData.IsClass);
            command.Parameters.AddWithValue("@LastPrice", assetData.LastPrice);
            command.Parameters.AddWithValue("@LastPriceDate", assetData.LastPriceDate ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@InitialAmountYTD", assetData.InitialAmountYTD);
            command.Parameters.AddWithValue("@FinalAmountYTD", assetData.FinalAmountYTD);
            command.Parameters.AddWithValue("@InOutYTD", assetData.InOutYTD);
            command.Parameters.AddWithValue("@GainsYTD", assetData.GainsYTD);
            command.Parameters.AddWithValue("@PerformanceYTD", assetData.PerformanceYTD);
            command.Parameters.AddWithValue("@InitialDateYTD", assetData.InitialDateYTD ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@FinalDateYTD", assetData.FinalDateYTD ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@NumDaysYTD", assetData.NumDaysYTD);
            command.Parameters.AddWithValue("@WeightedYTD", assetData.WeightedYTD);
            command.Parameters.AddWithValue("@InitialAmountD1", assetData.InitialAmountD1);
            command.Parameters.AddWithValue("@FinalAmountD1", assetData.FinalAmountD1);
            command.Parameters.AddWithValue("@InOutD1", assetData.InOutD1);
            command.Parameters.AddWithValue("@GainsD1", assetData.GainsD1);
            command.Parameters.AddWithValue("@PerformanceD1", assetData.PerformanceD1);
            command.Parameters.AddWithValue("@InitialDateD1", assetData.InitialDateD1 ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@FinalDateD1", assetData.FinalDateD1 ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@NumDaysD1", assetData.NumDaysD1);
            command.Parameters.AddWithValue("@WeightedD1", assetData.WeightedD1);
            command.Parameters.AddWithValue("@InitialAmountMTD", assetData.InitialAmountMTD);
            command.Parameters.AddWithValue("@FinalAmountMTD", assetData.FinalAmountMTD);
            command.Parameters.AddWithValue("@InOutMTD", assetData.InOutMTD);
            command.Parameters.AddWithValue("@GainsMTD", assetData.GainsMTD);
            command.Parameters.AddWithValue("@PerformanceMTD", assetData.PerformanceMTD);
            command.Parameters.AddWithValue("@InitialDateMTD", assetData.InitialDateMTD ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@FinalDateMTD", assetData.FinalDateMTD ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@NumDaysMTD", assetData.NumDaysMTD);
            command.Parameters.AddWithValue("@WeightedMTD", assetData.WeightedMTD);
            command.Parameters.AddWithValue("@InitialAmountM12", assetData.InitialAmountM12);
            command.Parameters.AddWithValue("@FinalAmountM12", assetData.FinalAmountM12);
            command.Parameters.AddWithValue("@InOutM12", assetData.InOutM12);
            command.Parameters.AddWithValue("@GainsM12", assetData.GainsM12);
            command.Parameters.AddWithValue("@PerformanceM12", assetData.PerformanceM12);
            command.Parameters.AddWithValue("@InitialDateM12", assetData.InitialDateM12 ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@FinalDateM12", assetData.FinalDateM12 ?? (object)DBNull.Value);
            command.Parameters.AddWithValue("@NumDaysM12", assetData.NumDaysM12);
            command.Parameters.AddWithValue("@WeightedM12", assetData.WeightedM12);


            command.ExecuteNonQuery();
        }
    }
}
