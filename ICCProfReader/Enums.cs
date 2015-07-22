namespace ICCProfReader
{
    //Data colour space signatures
    public enum ColorTypeEnum : uint
    {
        CIEXYZ = 0x58595A20,
        CIELAB = 0x4C616220,
        CIELUV = 0x4C757620,
        YCbCr = 0x59436272,
        CIEYxy = 0x59787920,
        RGB = 0x52474220,
        Gray = 0x47524159,
        HSV = 0x48535620,
        HLS = 0x484C5320,
        CMYK = 0x434D594B,
        CMY = 0x434D5920,
        _2colour = 0x32434C52,
        _3colour = 0x33434C52,
        _4colour = 0x34434C52,
        _5colour = 0x35434C52,
        _6colour = 0x36434C52,
        _7colour = 0x37434C52,
        _8colour = 0x38434C52,
        _9colour = 0x39434C52,
        _10colour = 0x41434C52,
        _11colour = 0x42434C52,
        _12colour = 0x43434C52,
        _13colour = 0x44434C52,
        _14colour = 0x45434C52,
        _15colour = 0x46434C52
    }

    public enum TagSignatureEnum : uint
    {
        AToB0Tag = 0x41324230, 					            
        AToB1Tag = 0x41324231,					            
        AToB2Tag = 0x41324232,					            
        blueMatrixColumnTag = 0x6258595A, 					
        blueTRCTag = 0x62545243,					        
        BToA0Tag = 0x42324130,					            
        BToA1Tag = 0x42324131,					            
        BToA2Tag = 0x42324132,					            
        BToD0Tag = 0x42324430,					            
        BToD1Tag = 0x42324431,					            
        BToD2Tag = 0x42324432,					            
        BToD3Tag = 0x42324433,					            
        calibrationDateTimeTag = 0x63616C74,				
        charTargetTag = 0x74617267,					        
        chromaticAdaptationTag = 0x63686164,				
        chromaticityTag = 0x6368726D,					    
        colorantOrderTag = 0x636C726F,					    
        colorantTableTag = 0x636C7274,					    
        colorantTableOutTag = 0x636C6F74,
        colorimetricIntentImageStateTag = 0x63696973,		
        copyrightTag = 0x63707274,					        
        deviceMfgDescTag = 0x646D6E64,					    
        deviceModelDescTag = 0x646D6464,					
        DToB0Tag = 0x44324230,					            
        DToB1Tag = 0x44324231,					            
        DToB2Tag = 0x44324232,					            
        DToB3Tag = 0x44324233,					            
        gamutTag = 0x67616D74,					            
        grayTRCTag = 0x6B545243,					        
        greenMatrixColumnTag = 0x6758595A,					
        greenTRCTag = 0x67545243,					        
        luminanceTag = 0x6C756D69,					        
        measurementTag = 0x6D656173,					    
        mediaWhitePointTag = 0x77747074,					
        namedColor2Tag = 0x6E636C32,					    
        outputResponseTag = 0x72657370,					    
        perceptualRenderingIntentGamutTag = 0x72696730,		
        preview0Tag = 0x70726530,					        
        preview1Tag = 0x70726531,					        
        preview2Tag = 0x70726532,					        
        profileDescriptionTag = 0x64657363,					
        profileSequenceDescTag = 0x70736571,				
        profileSequenceIdentifierTag = 0x70736964,			
        redMatrixColumnTag = 0x7258595A,					
        redTRCTag = 0x72545243,					            
        saturationRenderingIntentGamutTag = 0x72696732,		
        technologyTag = 0x74656368,					        
        viewingCondDescTag = 0x76756564,					
        viewingConditionsTag = 0x76696577					
    }

    //profileDescriptionTag must be multiLocalizedUnicode or text
    public enum TypeSignatureEnum : uint
    {
        Unknown,
        multiLocalizedUnicode = 0x6D6C7563,
        text = 0x74657874     
    }
}
