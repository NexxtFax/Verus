using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using Verus.WiiU.GeckoU;

namespace Verus
{
	public partial class MainForm : Form
	{
		Boolean flag;
		public MainForm()
		{
			this.on = 0x38600001;
			this.off = 0x38600000;
			this.on2 = 0x3BE00001;
			this.off2 = 0x3BE00000;
			this.blr = 0x4E800020;
			this.mflr = 0x7C0802A6;
			this.nop = 0x60000000;
			this.iptool = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "/Temp/";
			InitializeComponent();
		}
		#region Ram Writing
		public List<uint> list_1 = new List<uint>
		{
			0x7C0802A6,
			0x3D801200,
			0x804C0010,
			0x38420001,
			0x904C0010,
			0x2F822400,
			0x409C0008,
			0x4800001C,
			0x38000000,
			0x44000002,
			0x38007C00,
			0x44000002,
			0x38000001,
			0x44000002,
			0x3D8002F1,
			0x618CA4F0,
			0x7D8903A6,
			0x4E800420
		};

		public List<uint> list_2 = new List<uint>
		{
			0x3C401002,
			0x60425000,
			0x90020000,
			0x90220004,
			0x90420008,
			0x9062000C,
			0x90820010,
			0x90A20014,
			0x90C20018,
			0x90E2001C,
			0x91020020,
			0x91220024,
			0x91420028,
			0x9162002C,
			0x91820030,
			0x91A20034,
			0x91C20038,
			0x91E2003C,
			0x92020040,
			0x92220044,
			0x92420048,
			0x9262004C,
			0x92820050,
			0x92A20054,
			0x92C20058,
			0x92E2005C,
			0x93020060,
			0x93220064,
			0x93420068,
			0x9362006C,
			0x93820070,
			0x93A20074,
			0x93C20078,
			0x93E2007C,
			0xD0020080,
			0xD0220084,
			0xD0420088,
			0xD062008C,
			0xD0820090,
			0xD0A20094,
			0xD0C20098,
			0xD0E2009C,
			0xD10200A0,
			0xD12200A4,
			0xD14200A8,
			0xD16200AC,
			0xD18200B0,
			0xD1A200B4,
			0xD1C200B8,
			0xD1E200BC,
			0xD20200C0,
			0xD22200C4,
			0xD24200C8,
			0xD26200CC,
			0xD28200D0,
			0xD2A200D4,
			0xD2C200D8,
			0xD2E200DC,
			0xD30200E0,
			0xD32200E4,
			0xD34200E8,
			0xD36200EC,
			0xD38200F0,
			0xD3A200F4,
			0xD3C200F8,
			0xD3E200FC,
			0x48000125,
			0x3C401002,
			0x60425000,
			0x80020000,
			0x80220004,
			0x80420008,
			0x8062000C,
			0x80820010,
			0x80A20014,
			0x80C20018,
			0x80E2001C,
			0x81020020,
			0x81220024,
			0x81420028,
			0x8162002C,
			0x81820030,
			0x81A20034,
			0x81C20038,
			0x81E2003C,
			0x82020040,
			0x82220044,
			0x82420048,
			0x8262004C,
			0x82820050,
			0x82A20054,
			0x82C20058,
			0x82E2005C,
			0x83020060,
			0x83220064,
			0x83420068,
			0x8362006C,
			0x83820070,
			0x83A20074,
			0x83C20078,
			0x83E2007C,
			0xC0020080,
			0xC0220084,
			0xC0420088,
			0xC062008C,
			0xC0820090,
			0xC0A20094,
			0xC0C20098,
			0xC0E2009C,
			0xC10200A0,
			0xC12200A4,
			0xC14200A8,
			0xC16200AC,
			0xC18200B0,
			0xC1A200B4,
			0xC1C200B8,
			0xC1E200BC,
			0xC20200C0,
			0xC22200C4,
			0xC24200C8,
			0xC26200CC,
			0xC28200D0,
			0xC2A200D4,
			0xC2C200D8,
			0xC2E200DC,
			0xC30200E0,
			0xC32200E4,
			0xC34200E8,
			0xC36200EC,
			0xC38200F0,
			0xC3A200F4,
			0xC3C200F8,
			0xC3E200FC,
			0x3C401050,
			0x6042A200,
			0x3D80031A,
			0x618C44F8,
			0x7D8903A6,
			0x4E800420,
			0x3C201200,
			0x7C0802A6,
			0x90010000,
			0x48000044,
			0x48000178,
			0x4800019C,
			0x480001C0,
			0x480001E4,
			0x48000220,
			0x48000240,
			0x48000260,
			0x48000294,
			0x48000380,
			0x480003B8,
			0x48000614,
			0x48000A6C,
			0x3C201200,
			0x80010000,
			0x7C0803A6,
			0x4BFFFE95,
			0x3C201100,
			0x3C40102E,
			0x6042F7C0,
			0x80420000,
			0x2F820000,
			0x419E0120,
			0x3C40102F,
			0x60426B40,
			0xC1420000,
			0xC1620004,
			0x3C404500,
			0x60422000,
			0x90410110,
			0x3C404469,
			0x6042C000,
			0x90410118,
			0x3C40BF80,
			0x60420000,
			0x9041011C,
			0x3C40BFB9,
			0x6042999A,
			0x90410120,
			0x3C403FB9,
			0x6042999A,
			0x90410114,
			0x3C403E99,
			0x6042999A,
			0x90410124,
			0xC1E10110,
			0xFD4A7828,
			0xC1E10114,
			0xFD4A7824,
			0xC1E10118,
			0xFD6B7828,
			0xC1E1011C,
			0xFD6B03F2,
			0xC1E10120,
			0xFD6B7824,
			0xD1410130,
			0xD1610134,
			0x3C4010A0,
			0x6042A610,
			0x80620000,
			0x80630104,
			0x2F830000,
			0x419E0080,
			0x3C4042B4,
			0x60420000,
			0x9043014C,
			0x3C404334,
			0x60420000,
			0x90430148,
			0x80630158,
			0xC3210124,
			0xFD595028,
			0xD1410140,
			0xFD59502A,
			0xFD59502A,
			0xD1410144,
			0xFD795828,
			0xD1610148,
			0xFD79582A,
			0xFD79582A,
			0xD161014C,
			0xC1E1011C,
			0xC1410140,
			0xFD4F02B2,
			0xD9430000,
			0xC1410144,
			0xFD4F02B2,
			0xD9430018,
			0xC1610148,
			0xFD6F02F2,
			0xD9630010,
			0xC161014C,
			0xFD6F02F2,
			0xD9630028,
			0x4BFFFE8C,
			0x3C6010A0,
			0x6063A610,
			0x80630000,
			0x80630104,
			0x2F830000,
			0x419EFE78,
			0x3C403CA3,
			0x6042D70A,
			0x904303F0,
			0x4BFFFE68,
			0x3C6010A0,
			0x6063A610,
			0x80630000,
			0x80630104,
			0x2F830000,
			0x419EFE54,
			0x3C400101,
			0x60420101,
			0x9043015C,
			0x4BFFFE44,
			0x3C6010A0,
			0x6063A610,
			0x80630000,
			0x80630104,
			0x2F830000,
			0x419EFE30,
			0x3C401000,
			0x9043013D,
			0x9043012F,
			0x4BFFFE20,
			0x3C6010A0,
			0x6063A610,
			0x80630000,
			0x80630104,
			0x2F830000,
			0x419EFE0C,
			0x38400000,
			0x2F820001,
			0x419E0010,
			0x38400000,
			0x904301DA,
			0x4BFFFDF4,
			0x3C400101,
			0x60420101,
			0x904301DA,
			0x4BFFFDE4,
			0x3C6010A0,
			0x6063A610,
			0x80630000,
			0x80630104,
			0x2F830000,
			0x419EFDD0,
			0x38400004,
			0x90430910,
			0x4BFFFDC4,
			0x3C6010A0,
			0x6063A610,
			0x80630000,
			0x80630104,
			0x2F830000,
			0x419EFDB0,
			0x38400000,
			0x904308F8,
			0x4BFFFDA4,
			0x3C6010A0,
			0x6063A610,
			0x80630000,
			0x80630104,
			0x2F830000,
			0x419EFD90,
			0x8043070C,
			0x2F820000,
			0x419E0008,
			0x4BFFFD80,
			0x3C400100,
			0x60420101,
			0x9043070C,
			0x4BFFFD70,
			0x3C6010A0,
			0x6063A610,
			0x80630000,
			0x80630104,
			0x2F830000,
			0x419EFD5C,
			0x3C201100,
			0x3C40102F,
			0x60426A80,
			0x80420000,
			0x70430800,
			0x2C020800,
			0x70440400,
			0x2C020400,
			0x70450200,
			0x2C020200,
			0x70460100,
			0x2C020100,
			0x7C631BD6,
			0x7C8423D6,
			0x7CA52BD6,
			0x7CC633D6,
			0x3CE04040,
			0x3D00C040,
			0x3D204040,
			0x3D40C040,
			0x7CE719D6,
			0x7D0821D6,
			0x7D2929D6,
			0x7D4A31D6,
			0x90E10000,
			0x91010004,
			0x91210008,
			0x9141000C,
			0xC0E10000,
			0xC1010004,
			0xC1210008,
			0xC141000C,
			0x3D6010A0,
			0x616BA610,
			0x816B0000,
			0x816B0104,
			0x816B0158,
			0xC98B0000,
			0xC9AB0018,
			0xC9CB0010,
			0xC9EB0028,
			0xFD87602A,
			0xFDA7682A,
			0xFD88602A,
			0xFDA8682A,
			0xFDC9702A,
			0xFDE9782A,
			0xFDCA702A,
			0xFDEA782A,
			0xD98B0000,
			0xD9AB0018,
			0xD9CB0010,
			0xD9EB0028,
			0x4BFFFC84,
			0x3C60109C,
			0x6063D8E4,
			0x80630000,
			0x80630004,
			0x2F830000,
			0x419EFC70,
			0x38400000,
			0x9043002C,
			0x90430028,
			0x3C400100,
			0x9043000C,
			0x3C40FFFF,
			0x6042FFFF,
			0x90430024,
			0x4BFFFC4C,
			0x3C201100,
			0x60210D00,
			0x3C6010A0,
			0x6063A610,
			0x80630000,
			0x80630104,
			0x2F830000,
			0x419E01E8,
			0x80410004,
			0x2F820000,
			0x419E0188,
			0x3C80109C,
			0x6084D8E4,
			0x80840000,
			0x8084002C,
			0x2F840000,
			0x419E01C4,
			0x80410004,
			0x2F820000,
			0x419E0164,
			0x80A40038,
			0x80C4003C,
			0x2F850000,
			0x419E01A8,
			0x80410004,
			0x1C420008,
			0x7C851214,
			0x7F843040,
			0x419E0194,
			0x409C0190,
			0x80840000,
			0xC9430118,
			0xC9630128,
			0x80A30158,
			0xC9C50020,
			0xC9840118,
			0xC9A40128,
			0x80A40158,
			0xC9E50020,
			0xFD8A6028,
			0xFDAB6828,
			0xFDCF7028,
			0xD1810030,
			0xD1A10034,
			0xD1C10038,
			0x3C201108,
			0x6021F000,
			0x3D800383,
			0x618C310C,
			0xFC406090,
			0xFC206890,
			0x7D8903A6,
			0x4E800421,
			0x3C201100,
			0x38210D00,
			0x3C404334,
			0x90410040,
			0xC0410040,
			0xFC220072,
			0x3C404048,
			0x6042F5C3,
			0x90410040,
			0xC0410040,
			0xFC211024,
			0x3C4042B4,
			0x90410040,
			0xC0410040,
			0xFC22082A,
			0xFC200818,
			0xD0230148,
			0xC1810030,
			0xC1A10034,
			0xFD8C0332,
			0xFDAD0372,
			0xFC2D602A,
			0x3C201108,
			0x6021F128,
			0x3D800383,
			0x618C23CC,
			0x7D8903A6,
			0x4E800421,
			0x3C201100,
			0x60210D00,
			0xC0410038,
			0x3C201108,
			0x6021F000,
			0x3D800383,
			0x618C310C,
			0x7D8903A6,
			0x4E800421,
			0x3C201100,
			0x38210D00,
			0x3C404334,
			0x90410040,
			0xC0410040,
			0xFC220072,
			0x3C404048,
			0x6042F5C3,
			0x90410040,
			0xC0410040,
			0xFC211024,
			0x3C4042B4,
			0x90410040,
			0xC0410040,
			0xFC220828,
			0xFC200818,
			0xFC200850,
			0xD023014C,
			0x3C201100,
			0x38210D00,
			0x80410100,
			0x7C4803A6,
			0x3C40102E,
			0x6042FA64,
			0x80420000,
			0x70420800,
			0x2F820800,
			0x419E0028,
			0x3C40102E,
			0x6042FA64,
			0x80420000,
			0x70420200,
			0x2F820200,
			0x419E003C,
			0x38400000,
			0x90410000,
			0x48000064,
			0x38400000,
			0x90410008,
			0x80410008,
			0x2F820001,
			0x419E0010,
			0x38400000,
			0x90410004,
			0x48000044,
			0x38400001,
			0x90410004,
			0x48000038,
			0x38400001,
			0x90410008,
			0x81810000,
			0x2F8C0001,
			0x419EFFC0,
			0x39800001,
			0x7D8903A6,
			0x38400001,
			0x90410000,
			0x80410004,
			0x38420001,
			0x90410004,
			0x4200FFEC,
			0x4BFFF9F0,
			0x48000349,
			0x2F830001,
			0x419E0450,
			0x48000009,
			0x48000448,
			0x7C220B78,
			0x3C201100,
			0x60210DF0,
			0x90410004,
			0x7C4802A6,
			0x90410000,
			0x3C80109C,
			0x6084D8E4,
			0x80840000,
			0x8084002C,
			0x2F830000,
			0x80A40038,
			0x80C4003C,
			0x7CA53050,
			0x38C00008,
			0x7CA533D6,
			0x2F850001,
			0x419E0020,
			0x38400001,
			0x2F820000,
			0x419E0014,
			0x7F822840,
			0x409C000C,
			0x480001ED,
			0x4800002D,
			0x3C201100,
			0x60210E70,
			0x38400000,
			0x90410014,
			0x3C201100,
			0x60210DF0,
			0x80410000,
			0x80210004,
			0x7C4803A6,
			0x4E800020,
			0x7C220B78,
			0x3C201100,
			0x60210ED0,
			0x90410000,
			0x7C4802A6,
			0x90410004,
			0x3C201100,
			0x60210E70,
			0x80810014,
			0x2F840000,
			0x3C201100,
			0x60210ED0,
			0x419E017C,
			0x3C201100,
			0x60210ED0,
			0x3C6010A0,
			0x6063A610,
			0x80630000,
			0x80630104,
			0xC9430118,
			0xC9630128,
			0x80A30158,
			0xC9850020,
			0xD1810020,
			0x80A40158,
			0xC9850020,
			0xD1810024,
			0xC9840118,
			0xC9A40128,
			0xFD8A6028,
			0xFDAB6828,
			0xD1810028,
			0xD1A1002C,
			0x3C201108,
			0x6021F000,
			0x3D800383,
			0x618C310C,
			0xFC406090,
			0xFC206890,
			0x7D8903A6,
			0x4E800421,
			0x3C201100,
			0x60210ED0,
			0x3C404334,
			0x90410030,
			0xC0410030,
			0xFC220072,
			0x3C404048,
			0x6042F5C3,
			0x90410030,
			0xC0410030,
			0xFC211024,
			0x3C4042B4,
			0x90410030,
			0xC0410030,
			0xFC22082A,
			0xFC200818,
			0xD0230148,
			0x3C201100,
			0x60210ED0,
			0xC1810028,
			0xC1A1002C,
			0xC1410020,
			0xC1610024,
			0xFD4B5028,
			0xD1410038,
			0xFD8C0332,
			0xFDAD0372,
			0xFD8D602A,
			0xFC206090,
			0x3C201108,
			0x6021F000,
			0x3D800383,
			0x618C23CC,
			0x7D8903A6,
			0x4E800421,
			0x3C201100,
			0x60210ED0,
			0xC0410038,
			0x3C201108,
			0x6021F000,
			0x3D800383,
			0x618C310C,
			0x7D8903A6,
			0x4E800421,
			0x3C201100,
			0x60210ED0,
			0x3C404334,
			0x90410030,
			0xC0410030,
			0xFC220072,
			0x3C404048,
			0x6042F5C3,
			0x90410030,
			0xC0410030,
			0xFC211024,
			0x3C4042B4,
			0x90410030,
			0xC0410030,
			0xFC220828,
			0xFC200818,
			0xFC200850,
			0x3C6010A0,
			0x6063A610,
			0x80630000,
			0x80630104,
			0xD023014C,
			0x80410004,
			0x80210000,
			0x7C4803A6,
			0x4E800020,
			0x7C220B78,
			0x3C201100,
			0x60210E50,
			0x90410010,
			0x7C4802A6,
			0x90410000,
			0x90810004,
			0x90A10008,
			0x3C6010A0,
			0x6063A610,
			0x80630000,
			0x80630104,
			0x2F830000,
			0x419E009C,
			0x9061000C,
			0x7CBD2B78,
			0x7C9E2378,
			0x7C7F1B78,
			0x3C201100,
			0x60210E70,
			0x93C10004,
			0x93A10008,
			0x38400001,
			0x90410000,
			0x3C40447A,
			0x90410010,
			0x38400000,
			0x90410014,
			0x3C201100,
			0x60210E70,
			0x80410000,
			0x80810004,
			0x80A10008,
			0x7F822840,
			0x409C0040,
			0x1C420008,
			0x80810004,
			0x80840038,
			0x7C822214,
			0x80840000,
			0x48000075,
			0xC0410010,
			0xFF811000,
			0x409C000C,
			0xD0210010,
			0x90810014,
			0x80410000,
			0x38420001,
			0x90410000,
			0x4BFFFFAC,
			0x3C201100,
			0x60210E50,
			0x80A10008,
			0x80810004,
			0x8061000C,
			0x80410000,
			0x80210010,
			0x7C4803A6,
			0x4E800020,
			0x3C6010A0,
			0x6063A610,
			0x80630000,
			0x80630104,
			0x2F830000,
			0x38600000,
			0x419E0008,
			0x4E800020,
			0x38600001,
			0x4E800020,
			0x7C220B78,
			0x3C201100,
			0x60210EA0,
			0x90410000,
			0x7C4802A6,
			0x90410004,
			0x90610008,
			0x9081000C,
			0xC9430118,
			0xC9630128,
			0x80630158,
			0xC9840118,
			0xC9A40128,
			0x80840158,
			0x90610010,
			0x90810014,
			0xFD4C5028,
			0xFD6D5828,
			0xD1410018,
			0xD161001C,
			0xFD8A02B2,
			0xFDAB02F2,
			0xFD8C682A,
			0x3C201108,
			0x6021F000,
			0x3D800383,
			0x618C23CC,
			0x7D8903A6,
			0xFC206090,
			0x4E800421,
			0x3C201100,
			0x60210EA0,
			0xFD400890,
			0x80610010,
			0x80810014,
			0xC9630020,
			0xC9840020,
			0xFD6C5828,
			0xD1610018,
			0xD181001C,
			0xFD8A02B2,
			0xFDAB02F2,
			0xFD8D602A,
			0x3C201108,
			0x6021F000,
			0x3D800383,
			0x618C23CC,
			0x7D8903A6,
			0xFC206090,
			0x4E800421,
			0x3C201100,
			0x60210EA0,
			0x8081000C,
			0x80610008,
			0x80410004,
			0x80210000,
			0x7C4803A6,
			0x4E800020,
			0x4BFFF598,
			0x3C201100,
			0x60212000,
			0x3C403C03,
			0x6042126F,
			0x90410004,
			0xC0410004,
			0xC0210000,
			0xFC22082A,
			0xD0210000,
			0x3C403F80,
			0x90410004,
			0xC0410004,
			0xC0210000,
			0xFF811000,
			0x409C0008,
			0x4800000C,
			0x38400000,
			0x90410000,
			0xC0210000,
			0x3C403F80,
			0x90410004,
			0xC0410004,
			0x3C403F80,
			0x90410004,
			0xC0610004,
			0x3D800262,
			0x618C4178,
			0x7D8903A6,
			0x4E800421,
			0x3C201000,
			0x90610000,
			0x4BFFF51C
		};
		#endregion

		public static Point newpoint = new Point();
		public static int x;
		public static int y;
		public static GeckoUCore GeckoU;
		public static GeckoUConnect GeckoUConnection;
		private uint off;
		private uint on;
		private uint on2;
		private uint off2;
		private uint blr;
		private uint mflr;
		private uint nop;
		private int numberPlayers;
		public string giveText;
		private string enchantText;
		private string xpText;
		private string enchantString;
		private string iptool;

		public bool IsMinecraft()
		{
			string[] mcIds = new[] { "50000101d7500", "50000101d9d00", "50000101dbe00" };
			return mcIds.Contains(GeckoU.ReadTitleId());
		}

		public void codeErr()
		{
			MessageBox.Show("Could not send data to Wii U.", "Verus Mod Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			MouseDown += this.xMouseDown;
			MouseMove += this.xMouseMove;
			MouseDown += this.xMouseDown;
			MouseMove += this.xMouseMove;
			this.Opacity = 0.1;
			flag = true;
			timer1.Start();
			try
            {
				connectTxTBox.Text = File.ReadAllText(iptool + "ip-verus");
			}
			catch
            {
				//ignored
            }
		}

		private void Close_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show("Are you sure you want to quit the Application?", "Verus", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
			{
				Application.Exit();
			}
		}

		private void guna2Button1_Click(object sender, EventArgs e)
		{
			this.WindowState = FormWindowState.Minimized;
		}

		private void timer1_Tick(object sender, EventArgs e)
		{
			if (flag)
			{
				if (this.Opacity <= 1.0)
				{
					this.Opacity += 0.145;
				}
				else
				{
					timer1.Stop();
				}
			}
		}

		#region Move Form
		private void xMouseDown(object sender, MouseEventArgs e)
		{
			x = Control.MousePosition.X - base.Location.X;
			y = Control.MousePosition.Y - base.Location.Y;
		}
		private void xMouseMove(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				newpoint = Control.MousePosition;
				newpoint.X -= x;
				newpoint.Y -= y;
				base.Location = newpoint;
			}
		}
		#endregion

		#region Connection
		private void connectBtn_Click(object sender, EventArgs e)
		{
			GeckoU = new GeckoUCore(connectTxTBox.Text);
			try
			{
				GeckoU.Tcp.Connect();
				if (!IsMinecraft())
				{
					MessageBox.Show(this, "You need to start Minecraft Wii U Edition to be able to connect to your Wii U", "Verus", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					GeckoU.Tcp.Close();
					connectBtn.Visible = true;
					disconnectBtn.Visible = false;
				}
				else
				{
					connectBtn.Visible = false;
					disconnectBtn.Visible = true;
					string input = "9421FFF093E1000C3FE03B00813F00002C090001418200403D20025A7C0802A661291AD0900100147D2903A64E8004213D2002296129CFFC386000017D2903A64E8004218001001439200001913F00007C0803A683E1000C382100104E800020";
					MainForm.GeckoU.makeAssembly(0x3900000, input);
					MainForm.GeckoU.CallFunction(0x3900000, new uint[1]);
					checkBoxCT.Checked = true;
					File.WriteAllText(iptool + "ip-verus", connectTxTBox.Text);

				}
			}
			catch
			{
				MessageBox.Show(this, "An error has occurred while connecting", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				connectBtn.Visible = true;
				disconnectBtn.Visible = false;
			}
		}

		private void checkBoxCT_CheckedChanged(object sender, EventArgs e)
		{
			if (checkBoxCT.Checked)
			{
				bool flag = MainForm.GeckoU.PeekUInt(0x3FFFFFF8) == 0x1;
				if (!flag)
				{
					for (int i = 0; i < this.list_2.Count; i++)
					{
						MainForm.GeckoU.WriteUInt(0x4000000 + uint.Parse(i.ToString()) * 0x4, this.list_2[i]);
					}
					for (int j = 0; j < this.list_1.Count; j++)
					{
						MainForm.GeckoU.WriteUInt(0x4400000 + uint.Parse(j.ToString()) * 0x4, this.list_1[j]);
					}
					MainForm.GeckoU.WriteUInt(0x4000238, 0x60000000);
					MainForm.GeckoU.WriteUInt(0x400023C, 0x60000000);
					MainForm.GeckoU.WriteUInt(0x4000240, 0x60000000);
					MainForm.GeckoU.WriteUInt(0x4000244, 0x60000000);
					MainForm.GeckoU.WriteUInt(0x400024C, 0x60000000);
					MainForm.GeckoU.WriteUInt(0x4000250, 0x60000000);
					MainForm.GeckoU.WriteUInt(0x4000254, 0x60000000);
					MainForm.GeckoU.WriteUInt(0x4000258, 0x60000000);
					MainForm.GeckoU.WriteUInt(0x400025C, 0x60000000);
					MainForm.GeckoU.WriteUInt(0x4000260, 0x60000000);
					MainForm.GeckoU.WriteUInt(0x4000264, 0x60000000);
					MainForm.GeckoU.WriteUInt(0x3FFFFFC, 0x7C0802A6);
					MainForm.GeckoU.WriteUInt(0x3FFFFFF8, 0x1);
				}
				MainForm.GeckoU.WriteUInt(0x31A44F4, 0x48E5BB08);
			}
		}

		private void disconnectBtn_Click(object sender, EventArgs e)
		{
			try
			{
				GeckoU.Tcp.Close();
				connectBtn.Visible = true;
				disconnectBtn.Visible = false;
				checkBoxCT.Checked = false;
			}
			catch
			{
				MessageBox.Show(this, "An error has occurred while disconnecting.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				connectBtn.Visible = false;
				disconnectBtn.Visible = true;
			}
		}
		#endregion

		#region Functions for Mods
		private void poke_fnc(uint address, uint num)
		{
			checked
			{
				if (num == 0x0)
				{
					MainForm.GeckoU.WriteUInt(address, on);
					MainForm.GeckoU.WriteUInt(address + 0x4, blr);
				}
				if (num == 0x1)
				{
					MainForm.GeckoU.WriteUInt(address, off);
					MainForm.GeckoU.WriteUInt(address + 0x4, blr);
				}
				if (num == 0x2)
				{
					MainForm.GeckoU.WriteUInt(address, on);
				}
				if (num == 0x3)
				{
					MainForm.GeckoU.WriteUInt(address, off);
				}
				if (num == 0x4)
				{
					MainForm.GeckoU.WriteUInt(address, 0x57C3063E);
				}
				if (num == 0x5)
				{
					MainForm.GeckoU.WriteUInt(address, blr);
				}
				if (num == 0x63)
				{
					MainForm.GeckoU.WriteUInt(address, 0x11002200);
				}
			}
		}

		private static bool smethod_8(string string_0, string string_1)
		{
			return string_0 == string_1;
		}

		private static string controlText_method(Control control_0)
		{
			return control_0.Text;
		}

		private static char smethod_2(string string_0, int int_0)
		{
			return string_0[int_0];
		}

		private void executeSetBuildWithDamage()
		{
			MainForm.GeckoU.WriteUInt(0x031A44F4, 0x7C0802A6);
			MainForm.GeckoU.WriteUInt(0x12000000, MainForm.GeckoU.PeekUInt(0x12000010));
			string input = "9421ff483d2012003cc03d003ce03a10920100783d403a108209000060e70030614a0034810700007c103040814a00003d203a1091e1007461290038910100609141006481e90000408102ac92a1008c3ea0800062a9000192e100943ee0109c912100687c0802a662e946a491c100703dc059809221007c3e200248924100803e400248926100843e600248928100883e80028b92c100903ec0028a930100983f00028b9321009c3f20109c934100a03f400304900100bc62316698936100a4625261bc938100a862738b2c93a100ac629409f893c100b06339d8e49121006c635aa5d893e100b461ce000462d6d6c4631825b83fe03d003ee04330807f000c2c0300004182019c812100607e2903a6839f00003b60000083bf00047f89e2148121006482bf00107fa9ea1483df00084e80042138a000407c641b787e4903a6386000007fcff2144e8004217ea4ab787e6903a67c751b784e80042138a10038388000247e8903a692a10038386000009361003c4e80042181590000388100407f4903a6814a0034814a087890610040936100447d4353784e8004213cdc800092e10030395dfffe90c100343d4a80003cde800081210068c821003038a0000091c10030388000007ec903a638600000c001003092e100289141002cfc210028c841002891c10028c001002892e1002090c10024fc420028c881002091c10020c001002092e100189121001cfc840028c861001891c10018c0010018fc6300284e80042181590000388100407f4903a6814a0034814a087890610040936100447d4353784e8004218121006c38c000003881005080a900007f0903a6938100083860000093a1000c93c100109381005093a1005493c100584e80042180d900007c6a1b783881004080c600347f4903a68066087893610044914100404e8004213bff00207c10f8404181fe54800100bc81c100708221007c7c0803a682410080826100848281008882a1008c82c1009082e10094830100988321009c834100a0836100a4838100a883a100ac83c100b083e100b481e1007482010078382100b84e80002060000000";
			MainForm.GeckoU.makeAssembly(0x03917BF4, input);
			MainForm.GeckoU.CallFunction64(0x03917BF4, new uint[1]);
			MainForm.GeckoU.WriteUInt(0x031A44F4, 0x48E5BB08);
		}

		private static string smethod_1(string string_0, string string_1)
		{
			return string_0 + string_1;
		}

		private static int smethod_5(string string_0)
		{
			return string_0.Length;
		}

		private static string smethod_4(Control control_0)
		{
			return control_0.Text;
		}

		private static void smethod_3(int int_0)
		{
			Thread.Sleep(int_0);
		}

		private void String_poke(uint address, string name)
		{
			uint[] array = new uint[1];
			uint num = 0x0;
			int num2 = smethod_5(name);
			checked
			{
				if (smethod_5(name) % 2 == 1)
				{
					name = smethod_1(name, " ");
					num2++;
				}
				for (int i = 0; i < num2; i++)
				{
					num = (num << 16 | (uint)MainForm.smethod_2(name, i));
					if ((i + 1) % 2 == 0)
					{
						Array.Resize<uint>(ref array, array.Length + 1);
						array[array.Length - 2] = num;
						num = 0x0;
					}
				}
				Array.Resize<uint>(ref array, array.Length - 1);
				uint num3 = 0x0;
				for (int j = 0; j < array.Length; j++)
				{
					MainForm.GeckoU.WriteUInt(address + num3, array[j]);
					num3 += 0x4;
					MainForm.smethod_3(2);
				}
			}
		}

		private void gck()
		{
			poke_fnc(0x10000000, 0x0);
			uint num = MainForm.GeckoU.PeekUInt(0x10000000);
			MainForm.GeckoU.WriteUInt(checked(num + 0x1000000), uint.MaxValue);
		}

		private void executeUpdateWorldInfo()
		{
			MainForm.GeckoU.clearString2(0x30000000, 0x30000100);
			MainForm.GeckoU.clearString2(0x38000000, 0x38000080);
			this.player1Label.Visible = false;
			this.player2Label.Visible = false;
			this.player3Label.Visible = false;
			this.player4Label.Visible = false;
			this.player5Label.Visible = false;
			this.player6Label.Visible = false;
			this.player7Label.Visible = false;
			this.player8Label.Visible = false;
			this.x1Label.Visible = false;
			this.y1Label3.Visible = false;
			this.z1Label3.Visible = false;
			this.x2Label.Visible = false;
			this.y2Label.Visible = false;
			this.z2Label.Visible = false;
			this.x3Label.Visible = false;
			this.y3Label.Visible = false;
			this.z3Label.Visible = false;
			this.x4Label.Visible = false;
			this.y4Label.Visible = false;
			this.z4Label.Visible = false;
			this.x5Label.Visible = false;
			this.y5Label.Visible = false;
			this.z5Label.Visible = false;
			this.x6Label.Visible = false;
			this.y6Label.Visible = false;
			this.z6Label.Visible = false;
			this.x7Label.Visible = false;
			this.y7Label.Visible = false;
			this.z7Label.Visible = false;
			this.x8Label.Visible = false;
			this.y8Label.Visible = false;
			this.z8Label.Visible = false;
			string input = "9421ffb87c0802a63d40109c3d2003189001004c614ad8e46129c87838800000806a00007d2903a64e800421814300c8812300cc7d2a48505529e8ff418200fc930100283f00026d934100303f40100093a1003c3fa010009321002c63bda0e09361003463182edc93810038635a000c93c100407c7c1b7893e100443bc000003fe030003b20001e3b60000057c91838388100087c6a482e7f0903a6932100243bde0001936100083bff0020936100203bbd00044e800421815c00c8813c00cc810100207d2a4850800100085529e8fe8161000c7c1e4840806100108081001480a1001880c1001c80e10024901fffe0917fffe4907fffe8909fffec90bffff090dffff4911ffff890fffffc911dfffc913a00004180ff78830100288321002c83410030836100348381003883a1003c83c1004083e100448001004c382100487c0803a64e800020";
			MainForm.GeckoU.makeAssembly(0x03917290, input);
			MainForm.GeckoU.CallFunction(0x03917290, new uint[1]);
			string input2 = "9421fff87c0802a63d40109c3d2003189001000c6129c878614ad8e47d2903a6806a0000388000004e800421810300c8812300cc7d2848505529e8ff418200407d2903a63d20380081480000392900103908000880ea000080e7005490e9fff080ea000080e7005890e9fff4814a0000814a005c9149fff84200ffd08001000c382100087c0803a64e80002060000000";
			MainForm.GeckoU.makeAssembly(0x039173D8, input2);
			MainForm.GeckoU.CallFunction(0x039173D8, new uint[1]);
			string input3 = "9421FFF87C0802A63D200316612968187C0802A67D2903A69001000C4E800421812300342C09000041820024814900F83D20103061293030814A0154816A0004814A000091690004914900008001000C3D20010F61296AE0382100087D2903A67C0803A64E80002060000000";
			MainForm.GeckoU.makeAssembly(0x03917468, input3);
			MainForm.GeckoU.CallFunction(0x03917468, new uint[1]);
			this.numberPlayers = 0;
			bool flag = MainForm.GeckoU.PeekUInt(0x30000014) == 0x0;
			if (!flag)
			{
				this.numberPlayers++;
			}
			bool flag2 = MainForm.GeckoU.PeekUInt(0x30000034) == 0x0;
			if (!flag2)
			{
				this.numberPlayers++;
			}
			bool flag3 = MainForm.GeckoU.PeekUInt(0x30000054) == 0x0;
			if (!flag3)
			{
				this.numberPlayers++;
			}
			bool flag4 = MainForm.GeckoU.PeekUInt(0x30000074) == 0x0;
			if (!flag4)
			{
				this.numberPlayers++;
			}
			bool flag5 = MainForm.GeckoU.PeekUInt(0x30000094) == 0x0;
			if (!flag5)
			{
				this.numberPlayers++;
			}
			bool flag6 = MainForm.GeckoU.PeekUInt(0x300000B4) == 0x0;
			if (!flag6)
			{
				this.numberPlayers++;
			}
			bool flag7 = MainForm.GeckoU.PeekUInt(0x300000D4) == 0x0;
			if (!flag7)
			{
				this.numberPlayers++;
			}
			bool flag8 = MainForm.GeckoU.PeekUInt(0x300000F4) == 0x0;
			if (!flag8)
			{
				this.numberPlayers++;
			}
			this.numberPlayersLabel.Text = this.numberPlayersText + this.numberPlayers.ToString();
			bool flag9 = this.numberPlayers >= 1;
			if (flag9)
			{
				bool flag10 = MainForm.GeckoU.PeekUInt(0x30000014) <= 0x10000000;
				if (flag10)
				{
					uint num = MainForm.GeckoU.PeekUInt(0x30000002);
					char c = (char)num;
					uint num2 = MainForm.GeckoU.PeekUInt(0x30000004);
					char c2 = (char)num2;
					uint num3 = MainForm.GeckoU.PeekUInt(0x30000006);
					char c3 = (char)num3;
					uint num4 = MainForm.GeckoU.PeekUInt(0x30000008);
					char c4 = (char)num4;
					uint num5 = MainForm.GeckoU.PeekUInt(0x3000000A);
					char c5 = (char)num5;
					uint num6 = MainForm.GeckoU.PeekUInt(0x3000000C);
					char c6 = (char)num6;
					uint num7 = MainForm.GeckoU.PeekUInt(0x3000000E);
					char c7 = (char)num7;
					this.player1Label.Text = string.Format("{0}{1}{2}{3}{4}{5}{6}", new object[]
					{
						c,
						c2,
						c3,
						c4,
						c5,
						c6,
						c7
					});
				}
				else
				{
					uint num8 = MainForm.GeckoU.PeekUInt(MainForm.GeckoU.PeekUInt(0x30000014) - 0x2);
					char c8 = (char)num8;
					uint num9 = MainForm.GeckoU.PeekUInt(MainForm.GeckoU.PeekUInt(0x30000014));
					char c9 = (char)num9;
					uint num10 = MainForm.GeckoU.PeekUInt(MainForm.GeckoU.PeekUInt(0x30000014) + 0x2);
					char c10 = (char)num10;
					uint num11 = MainForm.GeckoU.PeekUInt(MainForm.GeckoU.PeekUInt(0x30000014) + 0x4);
					char c11 = (char)num11;
					uint num12 = MainForm.GeckoU.PeekUInt(MainForm.GeckoU.PeekUInt(0x30000014) + 0x6);
					char c12 = (char)num12;
					uint num13 = MainForm.GeckoU.PeekUInt(MainForm.GeckoU.PeekUInt(0x30000014) + 0x8);
					char c13 = (char)num13;
					uint num14 = MainForm.GeckoU.PeekUInt(MainForm.GeckoU.PeekUInt(0x30000014) + 0xA);
					char c14 = (char)num14;
					uint num15 = MainForm.GeckoU.PeekUInt(MainForm.GeckoU.PeekUInt(0x30000014) + 0xC);
					char c15 = (char)num15;
					uint num16 = MainForm.GeckoU.PeekUInt(MainForm.GeckoU.PeekUInt(0x30000014) + 0xE);
					char c16 = (char)num16;
					uint num17 = MainForm.GeckoU.PeekUInt(MainForm.GeckoU.PeekUInt(0x30000014) + 0x10);
					char c17 = (char)num17;
					uint num18 = MainForm.GeckoU.PeekUInt(MainForm.GeckoU.PeekUInt(0x30000014) + 0x12);
					char c18 = (char)num18;
					uint num19 = MainForm.GeckoU.PeekUInt(MainForm.GeckoU.PeekUInt(0x30000014) + 0x14);
					char c19 = (char)num19;
					uint num20 = MainForm.GeckoU.PeekUInt(MainForm.GeckoU.PeekUInt(0x30000014) + 0x16);
					char c20 = (char)num20;
					uint num21 = MainForm.GeckoU.PeekUInt(MainForm.GeckoU.PeekUInt(0x30000014) + 0x18);
					char c21 = (char)num21;
					uint num22 = MainForm.GeckoU.PeekUInt(MainForm.GeckoU.PeekUInt(0x30000014) + 0x1A);
					char c22 = (char)num22;
					uint num23 = MainForm.GeckoU.PeekUInt(MainForm.GeckoU.PeekUInt(0x30000014) + 0x1C);
					char c23 = (char)num23;
					uint num24 = MainForm.GeckoU.PeekUInt(MainForm.GeckoU.PeekUInt(0x30000014) + 0x1E);
					char c24 = (char)num24;
					this.player1Label.Text = string.Format("{0}{1}{2}{3}{4}{5}{6}{7}{8}{9}{10}{11}{12}{13}{14}{15}{16}", new object[]
					{
						c8,
						c9,
						c10,
						c11,
						c12,
						c13,
						c14,
						c15,
						c16,
						c17,
						c18,
						c19,
						c20,
						c21,
						c22,
						c23,
						c24
					});
				}
				this.player1Label.Visible = true;
				this.player2Label.Visible = false;
				this.player3Label.Visible = false;
				this.player4Label.Visible = false;
				this.player5Label.Visible = false;
				this.player6Label.Visible = false;
				this.player7Label.Visible = false;
				this.player8Label.Visible = false;
			}
			bool flag11 = this.numberPlayers >= 2;
			if (flag11)
			{
				bool flag12 = MainForm.GeckoU.PeekUInt(0x30000014) == MainForm.GeckoU.PeekUInt(0x30000034);
				if (flag12)
				{
					uint num25 = MainForm.GeckoU.PeekUInt(0x30000022);
					char c25 = (char)num25;
					uint num26 = MainForm.GeckoU.PeekUInt(0x30000024);
					char c26 = (char)num26;
					uint num27 = MainForm.GeckoU.PeekUInt(0x30000026);
					char c27 = (char)num27;
					uint num28 = MainForm.GeckoU.PeekUInt(0x30000028);
					char c28 = (char)num28;
					uint num29 = MainForm.GeckoU.PeekUInt(0x3000002A);
					char c29 = (char)num29;
					uint num30 = MainForm.GeckoU.PeekUInt(0x3000002C);
					char c30 = (char)num30;
					uint num31 = MainForm.GeckoU.PeekUInt(0x3000002E);
					char c31 = (char)num31;
					this.player2Label.Text = string.Format("{0}{1}{2}{3}{4}{5}{6}", new object[]
					{
						c25,
						c26,
						c27,
						c28,
						c29,
						c30,
						c31
					});
				}
				else
				{
					uint num32 = MainForm.GeckoU.PeekUInt(MainForm.GeckoU.PeekUInt(0x30000034) - 0x2);
					char c32 = (char)num32;
					uint num33 = MainForm.GeckoU.PeekUInt(MainForm.GeckoU.PeekUInt(0x30000034));
					char c33 = (char)num33;
					uint num34 = MainForm.GeckoU.PeekUInt(MainForm.GeckoU.PeekUInt(0x30000034) + 0x2);
					char c34 = (char)num34;
					uint num35 = MainForm.GeckoU.PeekUInt(MainForm.GeckoU.PeekUInt(0x30000034) + 0x4);
					char c35 = (char)num35;
					uint num36 = MainForm.GeckoU.PeekUInt(MainForm.GeckoU.PeekUInt(0x30000034) + 0x6);
					char c36 = (char)num36;
					uint num37 = MainForm.GeckoU.PeekUInt(MainForm.GeckoU.PeekUInt(0x30000034) + 0x8);
					char c37 = (char)num37;
					uint num38 = MainForm.GeckoU.PeekUInt(MainForm.GeckoU.PeekUInt(0x30000034) + 0xA);
					char c38 = (char)num38;
					uint num39 = MainForm.GeckoU.PeekUInt(MainForm.GeckoU.PeekUInt(0x30000034) + 0xC);
					char c39 = (char)num39;
					uint num40 = MainForm.GeckoU.PeekUInt(MainForm.GeckoU.PeekUInt(0x30000034) + 0xE);
					char c40 = (char)num40;
					uint num41 = MainForm.GeckoU.PeekUInt(MainForm.GeckoU.PeekUInt(0x30000034) + 0x10);
					char c41 = (char)num41;
					uint num42 = MainForm.GeckoU.PeekUInt(MainForm.GeckoU.PeekUInt(0x30000034) + 0x12);
					char c42 = (char)num42;
					uint num43 = MainForm.GeckoU.PeekUInt(MainForm.GeckoU.PeekUInt(0x30000034) + 0x14);
					char c43 = (char)num43;
					uint num44 = MainForm.GeckoU.PeekUInt(MainForm.GeckoU.PeekUInt(0x30000034) + 0x16);
					char c44 = (char)num44;
					uint num45 = MainForm.GeckoU.PeekUInt(MainForm.GeckoU.PeekUInt(0x30000034) + 0x18);
					char c45 = (char)num45;
					uint num46 = MainForm.GeckoU.PeekUInt(MainForm.GeckoU.PeekUInt(0x30000034) + 0x1A);
					char c46 = (char)num46;
					uint num47 = MainForm.GeckoU.PeekUInt(MainForm.GeckoU.PeekUInt(0x30000034) + 0x1C);
					char c47 = (char)num47;
					uint num48 = MainForm.GeckoU.PeekUInt(MainForm.GeckoU.PeekUInt(0x30000034) + 0x1E);
					char c48 = (char)num48;
					this.player2Label.Text = string.Format("{0}{1}{2}{3}{4}{5}{6}{7}{8}{9}{10}{11}{12}{13}{14}{15}{16}", new object[]
					{
						c32,
						c33,
						c34,
						c35,
						c36,
						c37,
						c38,
						c39,
						c40,
						c41,
						c42,
						c43,
						c44,
						c45,
						c46,
						c47,
						c48
					});
				}
				this.player1Label.Visible = true;
				this.player2Label.Visible = true;
				this.player3Label.Visible = false;
				this.player4Label.Visible = false;
				this.player5Label.Visible = false;
				this.player6Label.Visible = false;
				this.player7Label.Visible = false;
				this.player8Label.Visible = false;
			}
			bool flag13 = this.numberPlayers >= 3;
			if (flag13)
			{
				bool flag14 = MainForm.GeckoU.PeekUInt(0x30000034) == MainForm.GeckoU.PeekUInt(0x30000054);
				if (flag14)
				{
					uint num49 = MainForm.GeckoU.PeekUInt(0x30000042);
					char c49 = (char)num49;
					uint num50 = MainForm.GeckoU.PeekUInt(0x30000044);
					char c50 = (char)num50;
					uint num51 = MainForm.GeckoU.PeekUInt(0x30000046);
					char c51 = (char)num51;
					uint num52 = MainForm.GeckoU.PeekUInt(0x30000048);
					char c52 = (char)num52;
					uint num53 = MainForm.GeckoU.PeekUInt(0x3000004A);
					char c53 = (char)num53;
					uint num54 = MainForm.GeckoU.PeekUInt(0x3000004C);
					char c54 = (char)num54;
					uint num55 = MainForm.GeckoU.PeekUInt(0x3000004E);
					char c55 = (char)num55;
					this.player3Label.Text = string.Format("{0}{1}{2}{3}{4}{5}{6}", new object[]
					{
						c49,
						c50,
						c51,
						c52,
						c53,
						c54,
						c55
					});
				}
				else
				{
					uint num56 = MainForm.GeckoU.PeekUInt(MainForm.GeckoU.PeekUInt(0x30000054) - 0x2);
					char c56 = (char)num56;
					uint num57 = MainForm.GeckoU.PeekUInt(MainForm.GeckoU.PeekUInt(0x30000054));
					char c57 = (char)num57;
					uint num58 = MainForm.GeckoU.PeekUInt(MainForm.GeckoU.PeekUInt(0x30000054) + 0x2);
					char c58 = (char)num58;
					uint num59 = MainForm.GeckoU.PeekUInt(MainForm.GeckoU.PeekUInt(0x30000054) + 0x4);
					char c59 = (char)num59;
					uint num60 = MainForm.GeckoU.PeekUInt(MainForm.GeckoU.PeekUInt(0x30000054) + 0x6);
					char c60 = (char)num60;
					uint num61 = MainForm.GeckoU.PeekUInt(MainForm.GeckoU.PeekUInt(0x30000054) + 0x8);
					char c61 = (char)num61;
					uint num62 = MainForm.GeckoU.PeekUInt(MainForm.GeckoU.PeekUInt(0x30000054) + 0xA);
					char c62 = (char)num62;
					uint num63 = MainForm.GeckoU.PeekUInt(MainForm.GeckoU.PeekUInt(0x30000054) + 0xC);
					char c63 = (char)num63;
					uint num64 = MainForm.GeckoU.PeekUInt(MainForm.GeckoU.PeekUInt(0x30000054) + 0xE);
					char c64 = (char)num64;
					uint num65 = MainForm.GeckoU.PeekUInt(MainForm.GeckoU.PeekUInt(0x30000054) + 0x10);
					char c65 = (char)num65;
					uint num66 = MainForm.GeckoU.PeekUInt(MainForm.GeckoU.PeekUInt(0x30000054) + 0x12);
					char c66 = (char)num66;
					uint num67 = MainForm.GeckoU.PeekUInt(MainForm.GeckoU.PeekUInt(0x30000054) + 0x14);
					char c67 = (char)num67;
					uint num68 = MainForm.GeckoU.PeekUInt(MainForm.GeckoU.PeekUInt(0x30000054) + 0x16);
					char c68 = (char)num68;
					uint num69 = MainForm.GeckoU.PeekUInt(MainForm.GeckoU.PeekUInt(0x30000054) + 0x18);
					char c69 = (char)num69;
					uint num70 = MainForm.GeckoU.PeekUInt(MainForm.GeckoU.PeekUInt(0x30000054) + 0x1A);
					char c70 = (char)num70;
					uint num71 = MainForm.GeckoU.PeekUInt(MainForm.GeckoU.PeekUInt(0x30000054) + 0x1C);
					char c71 = (char)num71;
					uint num72 = MainForm.GeckoU.PeekUInt(MainForm.GeckoU.PeekUInt(0x30000054) + 0x1E);
					char c72 = (char)num72;
					this.player3Label.Text = string.Format("{0}{1}{2}{3}{4}{5}{6}{7}{8}{9}{10}{11}{12}{13}{14}{15}{16}", new object[]
					{
						c56,
						c57,
						c58,
						c59,
						c60,
						c61,
						c62,
						c63,
						c64,
						c65,
						c66,
						c67,
						c68,
						c69,
						c70,
						c71,
						c72
					});
				}
				this.player1Label.Visible = true;
				this.player2Label.Visible = true;
				this.player3Label.Visible = true;
				this.player4Label.Visible = false;
				this.player5Label.Visible = false;
				this.player6Label.Visible = false;
				this.player7Label.Visible = false;
				this.player8Label.Visible = false;
			}
			bool flag15 = this.numberPlayers >= 4;
			if (flag15)
			{
				bool flag16 = MainForm.GeckoU.PeekUInt(0x30000054) == MainForm.GeckoU.PeekUInt(0x30000074);
				if (flag16)
				{
					uint num73 = MainForm.GeckoU.PeekUInt(0x30000062);
					char c73 = (char)num73;
					uint num74 = MainForm.GeckoU.PeekUInt(0x30000064);
					char c74 = (char)num74;
					uint num75 = MainForm.GeckoU.PeekUInt(0x30000066);
					char c75 = (char)num75;
					uint num76 = MainForm.GeckoU.PeekUInt(0x30000068);
					char c76 = (char)num76;
					uint num77 = MainForm.GeckoU.PeekUInt(0x3000006A);
					char c77 = (char)num77;
					uint num78 = MainForm.GeckoU.PeekUInt(0x3000006C);
					char c78 = (char)num78;
					uint num79 = MainForm.GeckoU.PeekUInt(0x3000006E);
					char c79 = (char)num79;
					this.player4Label.Text = string.Format("{0}{1}{2}{3}{4}{5}{6}", new object[]
					{
						c73,
						c74,
						c75,
						c76,
						c77,
						c78,
						c79
					});
				}
				else
				{
					uint num80 = MainForm.GeckoU.PeekUInt(MainForm.GeckoU.PeekUInt(0x30000074) - 0x2);
					char c80 = (char)num80;
					uint num81 = MainForm.GeckoU.PeekUInt(MainForm.GeckoU.PeekUInt(0x30000074));
					char c81 = (char)num81;
					uint num82 = MainForm.GeckoU.PeekUInt(MainForm.GeckoU.PeekUInt(0x30000074) + 0x2);
					char c82 = (char)num82;
					uint num83 = MainForm.GeckoU.PeekUInt(MainForm.GeckoU.PeekUInt(0x30000074) + 0x4);
					char c83 = (char)num83;
					uint num84 = MainForm.GeckoU.PeekUInt(MainForm.GeckoU.PeekUInt(0x30000074) + 0x6);
					char c84 = (char)num84;
					uint num85 = MainForm.GeckoU.PeekUInt(MainForm.GeckoU.PeekUInt(0x30000074) + 0x8);
					char c85 = (char)num85;
					uint num86 = MainForm.GeckoU.PeekUInt(MainForm.GeckoU.PeekUInt(0x30000074) + 0xA);
					char c86 = (char)num86;
					uint num87 = MainForm.GeckoU.PeekUInt(MainForm.GeckoU.PeekUInt(0x30000074) + 0xC);
					char c87 = (char)num87;
					uint num88 = MainForm.GeckoU.PeekUInt(MainForm.GeckoU.PeekUInt(0x30000074) + 0xE);
					char c88 = (char)num88;
					uint num89 = MainForm.GeckoU.PeekUInt(MainForm.GeckoU.PeekUInt(0x30000074) + 0x10);
					char c89 = (char)num89;
					uint num90 = MainForm.GeckoU.PeekUInt(MainForm.GeckoU.PeekUInt(0x30000074) + 0x12);
					char c90 = (char)num90;
					uint num91 = MainForm.GeckoU.PeekUInt(MainForm.GeckoU.PeekUInt(0x30000074) + 0x14);
					char c91 = (char)num91;
					uint num92 = MainForm.GeckoU.PeekUInt(MainForm.GeckoU.PeekUInt(0x30000074) + 0x16);
					char c92 = (char)num92;
					uint num93 = MainForm.GeckoU.PeekUInt(MainForm.GeckoU.PeekUInt(0x30000074) + 0x18);
					char c93 = (char)num93;
					uint num94 = MainForm.GeckoU.PeekUInt(MainForm.GeckoU.PeekUInt(0x30000074) + 0x1A);
					char c94 = (char)num94;
					uint num95 = MainForm.GeckoU.PeekUInt(MainForm.GeckoU.PeekUInt(0x30000074) + 0x1C);
					char c95 = (char)num95;
					uint num96 = MainForm.GeckoU.PeekUInt(MainForm.GeckoU.PeekUInt(0x30000074) + 0x1E);
					char c96 = (char)num96;
					this.player4Label.Text = string.Format("{0}{1}{2}{3}{4}{5}{6}{7}{8}{9}{10}{11}{12}{13}{14}{15}{16}", new object[]
					{
						c80,
						c81,
						c82,
						c83,
						c84,
						c85,
						c86,
						c87,
						c88,
						c89,
						c90,
						c91,
						c92,
						c93,
						c94,
						c95,
						c96
					});
				}
				this.player1Label.Visible = true;
				this.player2Label.Visible = true;
				this.player3Label.Visible = true;
				this.player4Label.Visible = true;
				this.player5Label.Visible = false;
				this.player6Label.Visible = false;
				this.player7Label.Visible = false;
				this.player8Label.Visible = false;
			}
			bool flag17 = this.numberPlayers >= 5;
			if (flag17)
			{
				bool flag18 = MainForm.GeckoU.PeekUInt(0x30000074) == MainForm.GeckoU.PeekUInt(0x30000094);
				if (flag18)
				{
					uint num97 = MainForm.GeckoU.PeekUInt(0x30000082);
					char c97 = (char)num97;
					uint num98 = MainForm.GeckoU.PeekUInt(0x30000084);
					char c98 = (char)num98;
					uint num99 = MainForm.GeckoU.PeekUInt(0x30000086);
					char c99 = (char)num99;
					uint num100 = MainForm.GeckoU.PeekUInt(0x30000088);
					char c100 = (char)num100;
					uint num101 = MainForm.GeckoU.PeekUInt(0x3000008A);
					char c101 = (char)num101;
					uint num102 = MainForm.GeckoU.PeekUInt(0x3000008C);
					char c102 = (char)num102;
					uint num103 = MainForm.GeckoU.PeekUInt(0x3000008E);
					char c103 = (char)num103;
					this.player5Label.Text = string.Format("{0}{1}{2}{3}{4}{5}{6}", new object[]
					{
						c97,
						c98,
						c99,
						c100,
						c101,
						c102,
						c103
					});
				}
				else
				{
					uint num104 = MainForm.GeckoU.PeekUInt(MainForm.GeckoU.PeekUInt(0x30000094) - 0x2);
					char c104 = (char)num104;
					uint num105 = MainForm.GeckoU.PeekUInt(MainForm.GeckoU.PeekUInt(0x30000094));
					char c105 = (char)num105;
					uint num106 = MainForm.GeckoU.PeekUInt(MainForm.GeckoU.PeekUInt(0x30000094) + 0x2);
					char c106 = (char)num106;
					uint num107 = MainForm.GeckoU.PeekUInt(MainForm.GeckoU.PeekUInt(0x30000094) + 0x4);
					char c107 = (char)num107;
					uint num108 = MainForm.GeckoU.PeekUInt(MainForm.GeckoU.PeekUInt(0x30000094) + 0x6);
					char c108 = (char)num108;
					uint num109 = MainForm.GeckoU.PeekUInt(MainForm.GeckoU.PeekUInt(0x30000094) + 0x8);
					char c109 = (char)num109;
					uint num110 = MainForm.GeckoU.PeekUInt(MainForm.GeckoU.PeekUInt(0x30000094) + 0xA);
					char c110 = (char)num110;
					uint num111 = MainForm.GeckoU.PeekUInt(MainForm.GeckoU.PeekUInt(0x30000094) + 0xC);
					char c111 = (char)num111;
					uint num112 = MainForm.GeckoU.PeekUInt(MainForm.GeckoU.PeekUInt(0x30000094) + 0xE);
					char c112 = (char)num112;
					uint num113 = MainForm.GeckoU.PeekUInt(MainForm.GeckoU.PeekUInt(0x30000094) + 0x10);
					char c113 = (char)num113;
					uint num114 = MainForm.GeckoU.PeekUInt(MainForm.GeckoU.PeekUInt(0x30000094) + 0x12);
					char c114 = (char)num114;
					uint num115 = MainForm.GeckoU.PeekUInt(MainForm.GeckoU.PeekUInt(0x30000094) + 0x14);
					char c115 = (char)num115;
					uint num116 = MainForm.GeckoU.PeekUInt(MainForm.GeckoU.PeekUInt(0x30000094) + 0x16);
					char c116 = (char)num116;
					uint num117 = MainForm.GeckoU.PeekUInt(MainForm.GeckoU.PeekUInt(0x30000094) + 0x18);
					char c117 = (char)num117;
					uint num118 = MainForm.GeckoU.PeekUInt(MainForm.GeckoU.PeekUInt(0x30000094) + 0x1A);
					char c118 = (char)num118;
					uint num119 = MainForm.GeckoU.PeekUInt(MainForm.GeckoU.PeekUInt(0x30000094) + 0x1C);
					char c119 = (char)num119;
					uint num120 = MainForm.GeckoU.PeekUInt(MainForm.GeckoU.PeekUInt(0x30000094) + 0x1E);
					char c120 = (char)num120;
					this.player5Label.Text = string.Format("{0}{1}{2}{3}{4}{5}{6}{7}{8}{9}{10}{11}{12}{13}{14}{15}{16}", new object[]
					{
						c104,
						c105,
						c106,
						c107,
						c108,
						c109,
						c110,
						c111,
						c112,
						c113,
						c114,
						c115,
						c116,
						c117,
						c118,
						c119,
						c120
					});
				}
				this.player1Label.Visible = true;
				this.player2Label.Visible = true;
				this.player3Label.Visible = true;
				this.player4Label.Visible = true;
				this.player5Label.Visible = true;
				this.player6Label.Visible = false;
				this.player7Label.Visible = false;
				this.player8Label.Visible = false;
			}
			bool flag19 = this.numberPlayers >= 6;
			if (flag19)
			{
				bool flag20 = MainForm.GeckoU.PeekUInt(0x30000094) == MainForm.GeckoU.PeekUInt(0x300000B4);
				if (flag20)
				{
					uint num121 = MainForm.GeckoU.PeekUInt(0x300000A2);
					char c121 = (char)num121;
					uint num122 = MainForm.GeckoU.PeekUInt(0x300000A4);
					char c122 = (char)num122;
					uint num123 = MainForm.GeckoU.PeekUInt(0x300000A6);
					char c123 = (char)num123;
					uint num124 = MainForm.GeckoU.PeekUInt(0x300000A8);
					char c124 = (char)num124;
					uint num125 = MainForm.GeckoU.PeekUInt(0x300000AA);
					char c125 = (char)num125;
					uint num126 = MainForm.GeckoU.PeekUInt(0x300000AC);
					char c126 = (char)num126;
					uint num127 = MainForm.GeckoU.PeekUInt(0x300000AE);
					char c127 = (char)num127;
					this.player6Label.Text = string.Format("{0}{1}{2}{3}{4}{5}{6}", new object[]
					{
						c121,
						c122,
						c123,
						c124,
						c125,
						c126,
						c127
					});
				}
				else
				{
					uint num128 = MainForm.GeckoU.PeekUInt(MainForm.GeckoU.PeekUInt(0x300000B4) - 0x2);
					char c128 = (char)num128;
					uint num129 = MainForm.GeckoU.PeekUInt(MainForm.GeckoU.PeekUInt(0x300000B4));
					char c129 = (char)num129;
					uint num130 = MainForm.GeckoU.PeekUInt(MainForm.GeckoU.PeekUInt(0x300000B4) + 0x2);
					char c130 = (char)num130;
					uint num131 = MainForm.GeckoU.PeekUInt(MainForm.GeckoU.PeekUInt(0x300000B4) + 0x4);
					char c131 = (char)num131;
					uint num132 = MainForm.GeckoU.PeekUInt(MainForm.GeckoU.PeekUInt(0x300000B4) + 0x6);
					char c132 = (char)num132;
					uint num133 = MainForm.GeckoU.PeekUInt(MainForm.GeckoU.PeekUInt(0x300000B4) + 0x8);
					char c133 = (char)num133;
					uint num134 = MainForm.GeckoU.PeekUInt(MainForm.GeckoU.PeekUInt(0x300000B4) + 0xA);
					char c134 = (char)num134;
					uint num135 = MainForm.GeckoU.PeekUInt(MainForm.GeckoU.PeekUInt(0x300000B4) + 0xC);
					char c135 = (char)num135;
					uint num136 = MainForm.GeckoU.PeekUInt(MainForm.GeckoU.PeekUInt(0x300000B4) + 0xE);
					char c136 = (char)num136;
					uint num137 = MainForm.GeckoU.PeekUInt(MainForm.GeckoU.PeekUInt(0x300000B4) + 0x10);
					char c137 = (char)num137;
					uint num138 = MainForm.GeckoU.PeekUInt(MainForm.GeckoU.PeekUInt(0x300000B4) + 0x12);
					char c138 = (char)num138;
					uint num139 = MainForm.GeckoU.PeekUInt(MainForm.GeckoU.PeekUInt(0x300000B4) + 0x14);
					char c139 = (char)num139;
					uint num140 = MainForm.GeckoU.PeekUInt(MainForm.GeckoU.PeekUInt(0x300000B4) + 0x16);
					char c140 = (char)num140;
					uint num141 = MainForm.GeckoU.PeekUInt(MainForm.GeckoU.PeekUInt(0x300000B4) + 0x18);
					char c141 = (char)num141;
					uint num142 = MainForm.GeckoU.PeekUInt(MainForm.GeckoU.PeekUInt(0x300000B4) + 0x1A);
					char c142 = (char)num142;
					uint num143 = MainForm.GeckoU.PeekUInt(MainForm.GeckoU.PeekUInt(0x300000B4) + 0x1C);
					char c143 = (char)num143;
					uint num144 = MainForm.GeckoU.PeekUInt(MainForm.GeckoU.PeekUInt(0x300000B4) + 0x1E);
					char c144 = (char)num144;
					this.player6Label.Text = string.Format("{0}{1}{2}{3}{4}{5}{6}{7}{8}{9}{10}{11}{12}{13}{14}{15}{16}", new object[]
					{
						c128,
						c129,
						c130,
						c131,
						c132,
						c133,
						c134,
						c135,
						c136,
						c137,
						c138,
						c139,
						c140,
						c141,
						c142,
						c143,
						c144
					});
				}
				this.player1Label.Visible = true;
				this.player2Label.Visible = true;
				this.player3Label.Visible = true;
				this.player4Label.Visible = true;
				this.player5Label.Visible = true;
				this.player6Label.Visible = true;
				this.player7Label.Visible = false;
				this.player8Label.Visible = false;
			}
			bool flag21 = this.numberPlayers >= 7;
			if (flag21)
			{
				bool flag22 = MainForm.GeckoU.PeekUInt(0x300000B4) == MainForm.GeckoU.PeekUInt(0x300000D4);
				if (flag22)
				{
					uint num145 = MainForm.GeckoU.PeekUInt(0x300000C2);
					char c145 = (char)num145;
					uint num146 = MainForm.GeckoU.PeekUInt(0x300000C4);
					char c146 = (char)num146;
					uint num147 = MainForm.GeckoU.PeekUInt(0x300000C6);
					char c147 = (char)num147;
					uint num148 = MainForm.GeckoU.PeekUInt(0x300000C8);
					char c148 = (char)num148;
					uint num149 = MainForm.GeckoU.PeekUInt(0x300000CA);
					char c149 = (char)num149;
					uint num150 = MainForm.GeckoU.PeekUInt(0x300000CC);
					char c150 = (char)num150;
					uint num151 = MainForm.GeckoU.PeekUInt(0x300000CE);
					char c151 = (char)num151;
					this.player7Label.Text = string.Format("{0}{1}{2}{3}{4}{5}{6}", new object[]
					{
						c145,
						c146,
						c147,
						c148,
						c149,
						c150,
						c151
					});
				}
				else
				{
					uint num152 = MainForm.GeckoU.PeekUInt(MainForm.GeckoU.PeekUInt(0x300000D4) - 0x2);
					char c152 = (char)num152;
					uint num153 = MainForm.GeckoU.PeekUInt(MainForm.GeckoU.PeekUInt(0x300000D4));
					char c153 = (char)num153;
					uint num154 = MainForm.GeckoU.PeekUInt(MainForm.GeckoU.PeekUInt(0x300000D4) + 0x2);
					char c154 = (char)num154;
					uint num155 = MainForm.GeckoU.PeekUInt(MainForm.GeckoU.PeekUInt(0x300000D4) + 0x4);
					char c155 = (char)num155;
					uint num156 = MainForm.GeckoU.PeekUInt(MainForm.GeckoU.PeekUInt(0x300000D4) + 0x6);
					char c156 = (char)num156;
					uint num157 = MainForm.GeckoU.PeekUInt(MainForm.GeckoU.PeekUInt(0x300000D4) + 0x8);
					char c157 = (char)num157;
					uint num158 = MainForm.GeckoU.PeekUInt(MainForm.GeckoU.PeekUInt(0x300000D4) + 0xA);
					char c158 = (char)num158;
					uint num159 = MainForm.GeckoU.PeekUInt(MainForm.GeckoU.PeekUInt(0x300000D4) + 0xC);
					char c159 = (char)num159;
					uint num160 = MainForm.GeckoU.PeekUInt(MainForm.GeckoU.PeekUInt(0x300000D4) + 0xE);
					char c160 = (char)num160;
					uint num161 = MainForm.GeckoU.PeekUInt(MainForm.GeckoU.PeekUInt(0x300000D4) + 0x10);
					char c161 = (char)num161;
					uint num162 = MainForm.GeckoU.PeekUInt(MainForm.GeckoU.PeekUInt(0x300000D4) + 0x12);
					char c162 = (char)num162;
					uint num163 = MainForm.GeckoU.PeekUInt(MainForm.GeckoU.PeekUInt(0x300000D4) + 0x14);
					char c163 = (char)num163;
					uint num164 = MainForm.GeckoU.PeekUInt(MainForm.GeckoU.PeekUInt(0x300000D4) + 0x16);
					char c164 = (char)num164;
					uint num165 = MainForm.GeckoU.PeekUInt(MainForm.GeckoU.PeekUInt(0x300000D4) + 0x18);
					char c165 = (char)num165;
					uint num166 = MainForm.GeckoU.PeekUInt(MainForm.GeckoU.PeekUInt(0x300000D4) + 0x1A);
					char c166 = (char)num166;
					uint num167 = MainForm.GeckoU.PeekUInt(MainForm.GeckoU.PeekUInt(0x300000D4) + 0x1C);
					char c167 = (char)num167;
					uint num168 = MainForm.GeckoU.PeekUInt(MainForm.GeckoU.PeekUInt(0x300000D4) + 0x1E);
					char c168 = (char)num168;
					this.player7Label.Text = string.Format("{0}{1}{2}{3}{4}{5}{6}{7}{8}{9}{10}{11}{12}{13}{14}{15}{16}", new object[]
					{
						c152,
						c153,
						c154,
						c155,
						c156,
						c157,
						c158,
						c159,
						c160,
						c161,
						c162,
						c163,
						c164,
						c165,
						c166,
						c167,
						c168
					});
				}
				this.player1Label.Visible = true;
				this.player2Label.Visible = true;
				this.player3Label.Visible = true;
				this.player4Label.Visible = true;
				this.player5Label.Visible = true;
				this.player6Label.Visible = true;
				this.player7Label.Visible = true;
				this.player8Label.Visible = false;
			}
			bool flag23 = this.numberPlayers >= 8;
			if (flag23)
			{
				bool flag24 = MainForm.GeckoU.PeekUInt(805306580u) == MainForm.GeckoU.PeekUInt(805306612u);
				if (flag24)
				{
					uint num169 = MainForm.GeckoU.PeekUInt(805306594u);
					char c169 = (char)num169;
					uint num170 = MainForm.GeckoU.PeekUInt(805306596u);
					char c170 = (char)num170;
					uint num171 = MainForm.GeckoU.PeekUInt(805306598u);
					char c171 = (char)num171;
					uint num172 = MainForm.GeckoU.PeekUInt(805306600u);
					char c172 = (char)num172;
					uint num173 = MainForm.GeckoU.PeekUInt(805306602u);
					char c173 = (char)num173;
					uint num174 = MainForm.GeckoU.PeekUInt(805306604u);
					char c174 = (char)num174;
					uint num175 = MainForm.GeckoU.PeekUInt(805306606u);
					char c175 = (char)num175;
					this.player8Label.Text = string.Format("{0}{1}{2}{3}{4}{5}{6}", new object[]
					{
						c169,
						c170,
						c171,
						c172,
						c173,
						c174,
						c175
					});
				}
				else
				{
					uint num176 = MainForm.GeckoU.PeekUInt(MainForm.GeckoU.PeekUInt(0x300000F4) - 0x2);
					char c176 = (char)num176;
					uint num177 = MainForm.GeckoU.PeekUInt(MainForm.GeckoU.PeekUInt(0x300000F4));
					char c177 = (char)num177;
					uint num178 = MainForm.GeckoU.PeekUInt(MainForm.GeckoU.PeekUInt(0x300000F4) + 0x2);
					char c178 = (char)num178;
					uint num179 = MainForm.GeckoU.PeekUInt(MainForm.GeckoU.PeekUInt(0x300000F4) + 0x4);
					char c179 = (char)num179;
					uint num180 = MainForm.GeckoU.PeekUInt(MainForm.GeckoU.PeekUInt(0x300000F4) + 0x6);
					char c180 = (char)num180;
					uint num181 = MainForm.GeckoU.PeekUInt(MainForm.GeckoU.PeekUInt(0x300000F4) + 0x8);
					char c181 = (char)num181;
					uint num182 = MainForm.GeckoU.PeekUInt(MainForm.GeckoU.PeekUInt(0x300000F4) + 0xA);
					char c182 = (char)num182;
					uint num183 = MainForm.GeckoU.PeekUInt(MainForm.GeckoU.PeekUInt(0x300000F4) + 0xC);
					char c183 = (char)num183;
					uint num184 = MainForm.GeckoU.PeekUInt(MainForm.GeckoU.PeekUInt(0x300000F4) + 0xE);
					char c184 = (char)num184;
					uint num185 = MainForm.GeckoU.PeekUInt(MainForm.GeckoU.PeekUInt(0x300000F4) + 0x10);
					char c185 = (char)num185;
					uint num186 = MainForm.GeckoU.PeekUInt(MainForm.GeckoU.PeekUInt(0x300000F4) + 0x12);
					char c186 = (char)num186;
					uint num187 = MainForm.GeckoU.PeekUInt(MainForm.GeckoU.PeekUInt(0x300000F4) + 0x14);
					char c187 = (char)num187;
					uint num188 = MainForm.GeckoU.PeekUInt(MainForm.GeckoU.PeekUInt(0x300000F4) + 0x16);
					char c188 = (char)num188;
					uint num189 = MainForm.GeckoU.PeekUInt(MainForm.GeckoU.PeekUInt(0x300000F4) + 0x18);
					char c189 = (char)num189;
					uint num190 = MainForm.GeckoU.PeekUInt(MainForm.GeckoU.PeekUInt(0x300000F4) + 0x1A);
					char c190 = (char)num190;
					uint num191 = MainForm.GeckoU.PeekUInt(MainForm.GeckoU.PeekUInt(0x300000F4) + 0x1C);
					char c191 = (char)num191;
					uint num192 = MainForm.GeckoU.PeekUInt(MainForm.GeckoU.PeekUInt(0x300000F4) + 0x1E);
					char c192 = (char)num192;
					this.player8Label.Text = string.Format("{0}{1}{2}{3}{4}{5}{6}{7}{8}{9}{10}{11}{12}{13}{14}{15}{16}", new object[]
					{
						c176,
						c177,
						c178,
						c179,
						c180,
						c181,
						c182,
						c183,
						c184,
						c185,
						c186,
						c187,
						c188,
						c189,
						c190,
						c191,
						c192
					});
				}
				this.player1Label.Visible = true;
				this.player2Label.Visible = true;
				this.player3Label.Visible = true;
				this.player4Label.Visible = true;
				this.player5Label.Visible = true;
				this.player6Label.Visible = true;
				this.player7Label.Visible = true;
				this.player8Label.Visible = true;
			}
			bool flag25 = this.numberPlayers >= 1;
			if (flag25)
			{
				uint num193 = MainForm.GeckoU.PeekUInt(0x38000000);
				uint num194 = MainForm.GeckoU.PeekUInt(0x38000004);
				uint num195 = MainForm.GeckoU.PeekUInt(0x38000008);
				string text = num193.ToString();
				bool flag26 = num193 > 0xFFFF;
				if (flag26)
				{
					num193 = uint.MaxValue + num193;
					text = "-" + (uint.MaxValue - num193).ToString();
				}
				string text2 = num194.ToString();
				bool flag27 = num194 > 0xFFFF;
				if (flag27)
				{
					num194 = uint.MaxValue + num194;
					text2 = "-" + (uint.MaxValue - num194).ToString();
				}
				string text3 = num195.ToString();
				bool flag28 = num195 > 0xFFFF;
				if (flag28)
				{
					num195 = uint.MaxValue + num195;
					text3 = "-" + (uint.MaxValue - num195).ToString();
				}
				this.x1Label.Text = text;
				this.y1Label3.Text = text2;
				this.z1Label3.Text = text3;
				this.x1Label.Visible = true;
				this.y1Label3.Visible = true;
				this.z1Label3.Visible = true;
				this.x2Label.Visible = false;
				this.y2Label.Visible = false;
				this.z2Label.Visible = false;
				this.x3Label.Visible = false;
				this.y3Label.Visible = false;
				this.z3Label.Visible = false;
				this.x4Label.Visible = false;
				this.y4Label.Visible = false;
				this.z4Label.Visible = false;
				this.x5Label.Visible = false;
				this.y5Label.Visible = false;
				this.z5Label.Visible = false;
				this.x6Label.Visible = false;
				this.y6Label.Visible = false;
				this.z6Label.Visible = false;
				this.x7Label.Visible = false;
				this.y7Label.Visible = false;
				this.z7Label.Visible = false;
				this.x8Label.Visible = false;
				this.y8Label.Visible = false;
				this.z8Label.Visible = false;
			}
			bool flag29 = this.numberPlayers >= 2;
			if (flag29)
			{
				uint num196 = MainForm.GeckoU.PeekUInt(0x38000010);
				uint num197 = MainForm.GeckoU.PeekUInt(0x38000014);
				uint num198 = MainForm.GeckoU.PeekUInt(0x38000018);
				string text4 = num196.ToString();
				bool flag30 = num196 > 0xFFFF;
				if (flag30)
				{
					num196 = uint.MaxValue + num196;
					text4 = "-" + (uint.MaxValue - num196).ToString();
				}
				string text5 = num197.ToString();
				bool flag31 = num197 > 0xFFFF;
				if (flag31)
				{
					num197 = uint.MaxValue + num197;
					text5 = "-" + (uint.MaxValue - num197).ToString();
				}
				string text6 = num198.ToString();
				bool flag32 = num198 > 0xFFFF;
				if (flag32)
				{
					num198 = uint.MaxValue + num198;
					text6 = "-" + (uint.MaxValue - num198).ToString();
				}
				this.x2Label.Text = text4;
				this.y2Label.Text = text5;
				this.z2Label.Text = text6;
				this.x1Label.Visible = true;
				this.y1Label3.Visible = true;
				this.z1Label3.Visible = true;
				this.x2Label.Visible = true;
				this.y2Label.Visible = true;
				this.z2Label.Visible = true;
				this.x3Label.Visible = false;
				this.y3Label.Visible = false;
				this.z3Label.Visible = false;
				this.x4Label.Visible = false;
				this.y4Label.Visible = false;
				this.z4Label.Visible = false;
				this.x5Label.Visible = false;
				this.y5Label.Visible = false;
				this.z5Label.Visible = false;
				this.x6Label.Visible = false;
				this.y6Label.Visible = false;
				this.z6Label.Visible = false;
				this.x7Label.Visible = false;
				this.y7Label.Visible = false;
				this.z7Label.Visible = false;
				this.x8Label.Visible = false;
				this.y8Label.Visible = false;
				this.z8Label.Visible = false;
			}
			bool flag33 = this.numberPlayers >= 3;
			if (flag33)
			{
				uint num199 = MainForm.GeckoU.PeekUInt(0x38000020);
				uint num200 = MainForm.GeckoU.PeekUInt(0x38000024);
				uint num201 = MainForm.GeckoU.PeekUInt(0x38000028);
				string text7 = num199.ToString();
				bool flag34 = num199 > 0xFFFF;
				if (flag34)
				{
					num199 = uint.MaxValue + num199;
					text7 = "-" + (uint.MaxValue - num199).ToString();
				}
				string text8 = num200.ToString();
				bool flag35 = num200 > 0xFFFF;
				if (flag35)
				{
					num200 = uint.MaxValue + num200;
					text8 = "-" + (uint.MaxValue - num200).ToString();
				}
				string text9 = num201.ToString();
				bool flag36 = num201 > 0xFFFF;
				if (flag36)
				{
					num201 = uint.MaxValue + num201;
					text9 = "-" + (uint.MaxValue - num201).ToString();
				}
				this.x3Label.Text = text7;
				this.y3Label.Text = text8;
				this.z3Label.Text = text9;
				this.x1Label.Visible = true;
				this.y1Label3.Visible = true;
				this.z1Label3.Visible = true;
				this.x2Label.Visible = true;
				this.y2Label.Visible = true;
				this.z2Label.Visible = true;
				this.x3Label.Visible = true;
				this.y3Label.Visible = true;
				this.z3Label.Visible = true;
				this.x4Label.Visible = false;
				this.y4Label.Visible = false;
				this.z4Label.Visible = false;
				this.x5Label.Visible = false;
				this.y5Label.Visible = false;
				this.z5Label.Visible = false;
				this.x6Label.Visible = false;
				this.y6Label.Visible = false;
				this.z6Label.Visible = false;
				this.x7Label.Visible = false;
				this.y7Label.Visible = false;
				this.z7Label.Visible = false;
				this.x8Label.Visible = false;
				this.y8Label.Visible = false;
				this.z8Label.Visible = false;
			}
			bool flag37 = this.numberPlayers >= 4;
			if (flag37)
			{
				uint num202 = MainForm.GeckoU.PeekUInt(0x38000030);
				uint num203 = MainForm.GeckoU.PeekUInt(0x38000034);
				uint num204 = MainForm.GeckoU.PeekUInt(0x38000038);
				string text10 = num202.ToString();
				bool flag38 = num202 > 0xFFFF;
				if (flag38)
				{
					num202 = uint.MaxValue + num202;
					text10 = "-" + (uint.MaxValue - num202).ToString();
				}
				string text11 = num203.ToString();
				bool flag39 = num203 > 0xFFFF;
				if (flag39)
				{
					num203 = uint.MaxValue + num203;
					text11 = "-" + (uint.MaxValue - num203).ToString();
				}
				string text12 = num204.ToString();
				bool flag40 = num204 > 0xFFFF;
				if (flag40)
				{
					num204 = uint.MaxValue + num204;
					text12 = "-" + (uint.MaxValue - num204).ToString();
				}
				this.x4Label.Text = text10;
				this.y4Label.Text = text11;
				this.z4Label.Text = text12;
				this.x1Label.Visible = true;
				this.y1Label3.Visible = true;
				this.z1Label3.Visible = true;
				this.x2Label.Visible = true;
				this.y2Label.Visible = true;
				this.z2Label.Visible = true;
				this.x3Label.Visible = true;
				this.y3Label.Visible = true;
				this.z3Label.Visible = true;
				this.x4Label.Visible = true;
				this.y4Label.Visible = true;
				this.z4Label.Visible = true;
				this.x5Label.Visible = false;
				this.y5Label.Visible = false;
				this.z5Label.Visible = false;
				this.x6Label.Visible = false;
				this.y6Label.Visible = false;
				this.z6Label.Visible = false;
				this.x7Label.Visible = false;
				this.y7Label.Visible = false;
				this.z7Label.Visible = false;
				this.x8Label.Visible = false;
				this.y8Label.Visible = false;
				this.z8Label.Visible = false;
			}
			bool flag41 = this.numberPlayers >= 5;
			if (flag41)
			{
				uint num205 = MainForm.GeckoU.PeekUInt(0x38000040);
				uint num206 = MainForm.GeckoU.PeekUInt(0x38000044);
				uint num207 = MainForm.GeckoU.PeekUInt(0x38000048);
				string text13 = num205.ToString();
				bool flag42 = num205 > 0xFFFF;
				if (flag42)
				{
					num205 = uint.MaxValue + num205;
					text13 = "-" + (uint.MaxValue - num205).ToString();
				}
				string text14 = num206.ToString();
				bool flag43 = num206 > 0xFFFF;
				if (flag43)
				{
					num206 = uint.MaxValue + num206;
					text14 = "-" + (uint.MaxValue - num206).ToString();
				}
				string text15 = num207.ToString();
				bool flag44 = num207 > 0xFFFF;
				if (flag44)
				{
					num207 = uint.MaxValue + num207;
					text15 = "-" + (uint.MaxValue - num207).ToString();
				}
				this.x5Label.Text = text13;
				this.y5Label.Text = text14;
				this.z5Label.Text = text15;
				this.x1Label.Visible = true;
				this.y1Label3.Visible = true;
				this.z1Label3.Visible = true;
				this.x2Label.Visible = true;
				this.y2Label.Visible = true;
				this.z2Label.Visible = true;
				this.x3Label.Visible = true;
				this.y3Label.Visible = true;
				this.z3Label.Visible = true;
				this.x4Label.Visible = true;
				this.y4Label.Visible = true;
				this.z4Label.Visible = true;
				this.x5Label.Visible = true;
				this.y5Label.Visible = true;
				this.z5Label.Visible = true;
				this.x6Label.Visible = false;
				this.y6Label.Visible = false;
				this.z6Label.Visible = false;
				this.x7Label.Visible = false;
				this.y7Label.Visible = false;
				this.z7Label.Visible = false;
				this.x8Label.Visible = false;
				this.y8Label.Visible = false;
				this.z8Label.Visible = false;
			}
			bool flag45 = this.numberPlayers >= 6;
			if (flag45)
			{
				uint num208 = MainForm.GeckoU.PeekUInt(0x38000050);
				uint num209 = MainForm.GeckoU.PeekUInt(0x38000054);
				uint num210 = MainForm.GeckoU.PeekUInt(0x38000058);
				string text16 = num208.ToString();
				bool flag46 = num208 > 0xFFFF;
				if (flag46)
				{
					num208 = uint.MaxValue + num208;
					text16 = "-" + (uint.MaxValue - num208).ToString();
				}
				string text17 = num209.ToString();
				bool flag47 = num209 > 0xFFFF;
				if (flag47)
				{
					num209 = uint.MaxValue + num209;
					text17 = "-" + (uint.MaxValue - num209).ToString();
				}
				string text18 = num210.ToString();
				bool flag48 = num210 > 0xFFFF;
				if (flag48)
				{
					num210 = uint.MaxValue + num210;
					text18 = "-" + (uint.MaxValue - num210).ToString();
				}
				this.x6Label.Text = text16;
				this.y6Label.Text = text17;
				this.z6Label.Text = text18;
				this.x1Label.Visible = true;
				this.y1Label3.Visible = true;
				this.z1Label3.Visible = true;
				this.x2Label.Visible = true;
				this.y2Label.Visible = true;
				this.z2Label.Visible = true;
				this.x3Label.Visible = true;
				this.y3Label.Visible = true;
				this.z3Label.Visible = true;
				this.x4Label.Visible = true;
				this.y4Label.Visible = true;
				this.z4Label.Visible = true;
				this.x5Label.Visible = true;
				this.y5Label.Visible = true;
				this.z5Label.Visible = true;
				this.x6Label.Visible = true;
				this.y6Label.Visible = true;
				this.z6Label.Visible = true;
				this.x7Label.Visible = false;
				this.y7Label.Visible = false;
				this.z7Label.Visible = false;
				this.x8Label.Visible = false;
				this.y8Label.Visible = false;
				this.z8Label.Visible = false;
			}
			bool flag49 = this.numberPlayers >= 7;
			if (flag49)
			{
				uint num211 = MainForm.GeckoU.PeekUInt(0x38000060);
				uint num212 = MainForm.GeckoU.PeekUInt(0x38000064);
				uint num213 = MainForm.GeckoU.PeekUInt(0x38000068);
				string text19 = num211.ToString();
				bool flag50 = num211 > 0xFFFF;
				if (flag50)
				{
					num211 = uint.MaxValue + num211;
					text19 = "-" + (uint.MaxValue - num211).ToString();
				}
				string text20 = num212.ToString();
				bool flag51 = num212 > 0xFFFF;
				if (flag51)
				{
					num212 = uint.MaxValue + num212;
					text20 = "-" + (uint.MaxValue - num212).ToString();
				}
				string text21 = num213.ToString();
				bool flag52 = num213 > 0xFFFF;
				if (flag52)
				{
					num213 = uint.MaxValue + num213;
					text21 = "-" + (uint.MaxValue - num213).ToString();
				}
				this.x7Label.Text = text19;
				this.y7Label.Text = text20;
				this.z7Label.Text = text21;
				this.x1Label.Visible = true;
				this.y1Label3.Visible = true;
				this.z1Label3.Visible = true;
				this.x2Label.Visible = true;
				this.y2Label.Visible = true;
				this.z2Label.Visible = true;
				this.x3Label.Visible = true;
				this.y3Label.Visible = true;
				this.z3Label.Visible = true;
				this.x4Label.Visible = true;
				this.y4Label.Visible = true;
				this.z4Label.Visible = true;
				this.x5Label.Visible = true;
				this.y5Label.Visible = true;
				this.z5Label.Visible = true;
				this.x6Label.Visible = true;
				this.y6Label.Visible = true;
				this.z6Label.Visible = true;
				this.x7Label.Visible = true;
				this.y7Label.Visible = true;
				this.z7Label.Visible = true;
				this.x8Label.Visible = false;
				this.y8Label.Visible = false;
				this.z8Label.Visible = false;
			}
			bool flag53 = this.numberPlayers >= 8;
			if (flag53)
			{
				uint num214 = MainForm.GeckoU.PeekUInt(0x38000070);
				uint num215 = MainForm.GeckoU.PeekUInt(0x38000074);
				uint num216 = MainForm.GeckoU.PeekUInt(0x38000078);
				string text22 = num214.ToString();
				bool flag54 = num214 > 0xFFFF;
				if (flag54)
				{
					num214 = uint.MaxValue + num214;
					text22 = "-" + (uint.MaxValue - num214).ToString();
				}
				string text23 = num215.ToString();
				bool flag55 = num215 > 0xFFFF;
				if (flag55)
				{
					num215 = uint.MaxValue + num215;
					text23 = "-" + (uint.MaxValue - num215).ToString();
				}
				string text24 = num216.ToString();
				bool flag56 = num216 > 0xFFFF;
				if (flag56)
				{
					num216 = uint.MaxValue + num216;
					text24 = "-" + (uint.MaxValue - num216).ToString();
				}
				this.x8Label.Text = text22;
				this.y8Label.Text = text23;
				this.z8Label.Text = text24;
				this.x1Label.Visible = true;
				this.y1Label3.Visible = true;
				this.z1Label3.Visible = true;
				this.x2Label.Visible = true;
				this.y2Label.Visible = true;
				this.z2Label.Visible = true;
				this.x3Label.Visible = true;
				this.y3Label.Visible = true;
				this.z3Label.Visible = true;
				this.x4Label.Visible = true;
				this.y4Label.Visible = true;
				this.z4Label.Visible = true;
				this.x5Label.Visible = true;
				this.y5Label.Visible = true;
				this.z5Label.Visible = true;
				this.x6Label.Visible = true;
				this.y6Label.Visible = true;
				this.z6Label.Visible = true;
				this.x7Label.Visible = true;
				this.y7Label.Visible = true;
				this.z7Label.Visible = true;
				this.x8Label.Visible = true;
				this.y8Label.Visible = true;
				this.z8Label.Visible = true;
			}
			bool flag57 = this.numberPlayers >= 1;
			if (flag57)
			{
				this.givePlayerBox.Items[0] = this.player1Label.Text;
				this.EnchantPlayer.Items[0] = this.player1Label.Text;
			}
			else
			{
				this.givePlayerBox.Items[0] = "";
				this.EnchantPlayer.Items[0] = "";
			}
			bool flag58 = this.numberPlayers >= 2;
			if (flag58)
			{
				this.givePlayerBox.Items[1] = this.player2Label.Text;
				this.EnchantPlayer.Items[1] = this.player2Label.Text;
			}
			else
			{
				this.givePlayerBox.Items[1] = "";
				this.EnchantPlayer.Items[1] = "";
			}
			bool flag59 = this.numberPlayers >= 3;
			if (flag59)
			{
				this.givePlayerBox.Items[2] = this.player3Label.Text;
				this.EnchantPlayer.Items[2] = this.player3Label.Text;
			}
			else
			{
				this.givePlayerBox.Items[2] = "";
				this.EnchantPlayer.Items[2] = "";
			}
			bool flag60 = this.numberPlayers >= 4;
			if (flag60)
			{
				this.givePlayerBox.Items[3] = this.player4Label.Text;
				this.EnchantPlayer.Items[3] = this.player4Label.Text;
			}
			else
			{
				this.givePlayerBox.Items[3] = "";
				this.EnchantPlayer.Items[3] = "";
			}
			bool flag61 = this.numberPlayers >= 5;
			if (flag61)
			{
				this.givePlayerBox.Items[4] = this.player5Label.Text;
				this.EnchantPlayer.Items[4] = this.player5Label.Text;
			}
			else
			{
				this.givePlayerBox.Items[4] = "";
				this.EnchantPlayer.Items[4] = "";
			}
			bool flag62 = this.numberPlayers >= 6;
			if (flag62)
			{
				this.givePlayerBox.Items[5] = this.player6Label.Text;
				this.EnchantPlayer.Items[5] = this.player6Label.Text;
			}
			else
			{
				this.givePlayerBox.Items[5] = "";
				this.EnchantPlayer.Items[5] = "";
			}
			bool flag63 = this.numberPlayers >= 7;
			if (flag63)
			{
				this.givePlayerBox.Items[6] = this.player7Label.Text;
				this.EnchantPlayer.Items[6] = this.player7Label.Text;
			}
			else
			{
				this.givePlayerBox.Items[6] = "";
				this.EnchantPlayer.Items[6] = "";
			}
			bool flag64 = this.numberPlayers >= 8;
			if (flag64)
			{
				this.givePlayerBox.Items[7] = this.player8Label.Text;
				this.EnchantPlayer.Items[7] = this.player8Label.Text;
			}
			else
			{
				this.givePlayerBox.Items[7] = "";
				this.EnchantPlayer.Items[7] = "";
			}
			ulong num217 = MainForm.GeckoU.PeekULong(271593520u);
			bool flag65 = num217 > 11529215046068469760UL;
			if (flag65)
			{
				num217 = ulong.MaxValue - num217 + 1UL;
				this.seedText.Text = "Seed : -" + num217.ToString();
			}
			else
			{
				this.seedText.Text = "Seed : " + num217.ToString();
			}
		}

		private void GiveItemBTN_Click(object sender, EventArgs e)
		{

			{
				bool flag9 = this.givePlayerBox.Text == "*Not Connected*";
				if (flag9)
				{
					MainForm.GeckoU.WriteUInt(822084112u, 0x0);
					this.giveText = string.Concat(new string[]
					{
						"Verus: Given Item (ID: ",
						this.giveItemID.Value.ToString(),
						") to ",
						this.givePlayerBox.Text,
						""
					});
				}
				bool flag11 = this.givePlayerBox.SelectedIndex == 0;
				if (flag11)
				{
					MainForm.GeckoU.WriteUInt(0x31000210, 0x0);
					this.giveText = string.Concat(new string[]
					{
						"Verus: Given Item (ID: ",
						this.giveItemID.Value.ToString(),
						") to ",
						this.givePlayerBox.Text,
						""
					});
				}
				bool flag12 = this.givePlayerBox.SelectedIndex == 1;
				if (flag12)
				{
					MainForm.GeckoU.WriteUInt(0x31000210, 0x8);
					this.giveText = string.Concat(new string[]
					{
						"Verus: Given Item (ID: ",
						this.giveItemID.Value.ToString(),
						") to ",
						this.givePlayerBox.Text,
						""
					});
				}
				bool flag13 = this.givePlayerBox.SelectedIndex == 2;
				if (flag13)
				{
					MainForm.GeckoU.WriteUInt(0x31000210, 0x10);
					this.giveText = string.Concat(new string[]
					{
						"Verus: Given Item (ID: ",
						this.giveItemID.Value.ToString(),
						") to ",
						this.givePlayerBox.Text,
						""
					});
				}
				bool flag14 = this.givePlayerBox.SelectedIndex == 3;
				if (flag14)
				{
					MainForm.GeckoU.WriteUInt(0x31000210, 0x18);
					this.giveText = string.Concat(new string[]
					{
						"Verus: Given Item (ID: ",
						this.giveItemID.Value.ToString(),
						") to ",
						this.givePlayerBox.Text,
						""
					});
				}
				bool flag15 = this.givePlayerBox.SelectedIndex == 4;
				if (flag15)
				{
					MainForm.GeckoU.WriteUInt(0x31000210, 0x20);
					this.giveText = string.Concat(new string[]
					{
						"Verus: Given Item (ID: ",
						this.giveItemID.Value.ToString(),
						") to ",
						this.givePlayerBox.Text,
						""
					});
				}
				bool flag16 = this.givePlayerBox.SelectedIndex == 5;
				if (flag16)
				{
					MainForm.GeckoU.WriteUInt(0x31000210, 0x28);
					this.giveText = string.Concat(new string[]
					{
						"Verus: Given Item (ID: ",
						this.giveItemID.Value.ToString(),
						") to ",
						this.givePlayerBox.Text,
						""
					});
				}
				bool flag17 = this.givePlayerBox.SelectedIndex == 6;
				if (flag17)
				{
					MainForm.GeckoU.WriteUInt(0x31000210, 0x30);
					this.giveText = string.Concat(new string[]
					{
						"Verus: Given Item (ID: ",
						this.giveItemID.Value.ToString(),
						") to ",
						this.givePlayerBox.Text,
						""
					});
				}
				bool flag18 = this.givePlayerBox.SelectedIndex == 7;
				if (flag18)
				{
					MainForm.GeckoU.WriteUInt(0x31000210, 0x38);
					this.giveText = string.Concat(new string[]
					{
						"Verus: Given Item (ID: ",
						this.giveItemID.Value.ToString(),
						") to ",
						this.givePlayerBox.Text,
						""
					});
				}
				MainForm.GeckoU.clearString2(0x1061F270, 0x1061F360);
				MainForm.GeckoU.WriteStringUTF16(0x1061F270, this.giveText);
				MainForm.GeckoU.WriteUInt(0x31000214, MainForm.GeckoU.Mix(0x0, this.giveItemID.Value));
				MainForm.GeckoU.WriteUInt(0x3100021C, MainForm.GeckoU.Mix(0x0, this.giveItemDamage.Value));
				MainForm.GeckoU.WriteUInt(0x31000218, MainForm.GeckoU.Mix(0x0, this.giveItemNumber.Value));
				this.executeGiveItem();
			}
		}

		private void executeGetBuildWithDamage()
		{
			if (this.startY.Value > this.endY.Value)
			{
				decimal value = this.endY.Value;
				this.endY.Value = this.startY.Value;
				this.startY.Value = value;
			}
			uint value3;
			if (this.startX.Value < 0m)
			{
				decimal value2 = 4294967295m + this.startX.Value;
				value3 = (uint)value2;
			}
			else
			{
				value3 = (uint)this.startX.Value;
			}
			MainForm.GeckoU.WriteUInt(974127104u, value3);
			uint value5;
			if (this.startY.Value < 0m)
			{
				decimal value4 = 4294967295m + this.startY.Value;
				value5 = (uint)value4;
			}
			else
			{
				value5 = (uint)this.startY.Value;
			}
			MainForm.GeckoU.WriteUInt(974127108u, value5);
			uint value7;
			if (this.startZ.Value < 0m)
			{
				decimal value6 = 4294967295m + this.startZ.Value;
				value7 = (uint)value6;
			}
			else
			{
				value7 = (uint)this.startZ.Value;
			}
			MainForm.GeckoU.WriteUInt(974127112u, value7);
			uint value9;
			if (this.endX.Value < 0m)
			{
				decimal value8 = 4294967295m + this.endX.Value;
				value9 = (uint)value8;
			}
			else
			{
				value9 = (uint)this.endX.Value;
			}
			MainForm.GeckoU.WriteUInt(974127120u, value9);
			uint value11;
			if (this.endY.Value < 0m)
			{
				decimal value10 = 4294967295m + this.endY.Value;
				value11 = (uint)value10;
			}
			else
			{
				value11 = (uint)this.endY.Value;
			}
			MainForm.GeckoU.WriteUInt(974127124u, value11);
			uint value13;
			if (this.endZ.Value < 0m)
			{
				decimal value12 = 4294967295m + this.endZ.Value;
				value13 = (uint)value12;
			}
			else
			{
				value13 = (uint)this.endZ.Value;
			}
			MainForm.GeckoU.WriteUInt(974127128u, value13);
			MainForm.GeckoU.WriteUInt(52053236u, 2080899750u);
			string input = "9421ff987c0802a63d203a103d403a109001006c61290010924100307d800026824900003d2003186129c8789321004c7d2903a63d203a10832a000061290018614a00089221002c934100503cc0109c834a00003ce03a10822900003d003a107cb9905093e1006460c6d8e460e70004610800147ffa88509181001c38800000926100342d050000826700009281003893c10060828800008066000090a100107e93a05093e100082d9400004e8004217c7e1b784188017c418c01402e1f000092a1003c4190042c418a054091c1002091e100249201002892c1004092e1004493010048936100549381005893a1005c4091051039ffffff55ef2834394f00203d2002543ec002549141000c612fccac62d6d8007f32cb783ae000003ea03d003e001200418e00943b000000419200807dd89a14409103a4836100087ebfab783ba000007e3dd2147dc573787e268b787e4493787de903a67fc3f3783bff00204e8004217e268b787c7c1b787dc573787e4493787fc3f3787ec903a64e800421377bffff93bfffe83bbd0001939fffec907ffff092ffffe0931fffe493f000004082ffa48121000c7eb54a143b1800017c14c0004181ff78812100103af700013a5200017c09b8004181ff5c81c1002081e100248201002882c1004082e1004483010048836100548381005883a1005c4192030482a1003c8001006c8181001c8221002c7c0803a6824100307d83812082610034828100388321004c8341005083c1006083e10064382100684e80002041acffc88121000892a1003c3ea03d002e0900004091015841aeffac91c1002091e100249201002892c1004092e1004493010048936100549381005893a1005c409103a48121000839e9ffff55ef28343e4002543ec002543a2f00206252ccac62d6d8003ae000003e0012003b0000004192007c7dd89a1440910238836100087ebfab783ba000007dfdd2147dc573787de67b787f24cb787e4903a67fc3f3783bff00204e8004217de67b787c7c1b787dc573787f24cb787fc3f3787ec903a64e800421377bffff93bfffe83bbd0001939fffec907ffff092ffffe0931fffe493f000004082ffa47eb58a143b1800017c14c0004181ff7c812100103af7ffff3b39ffff7c09b8004082ff648001006c8181001c81c100207c0803a681e100247d8381208201002882a1003c82c1004082e1004483010048836100548381005883a1005c8221002c8241003082610034828100388321004c8341005083c1006083e10064382100684e80002091c1002091e100249201002892c1004092e1004493010048936100549381005893a1005c4190026c3a000000393000203e4002549121000c3ee00254812100086252ccac62f7d8007f3ccb787d2900d03b000000912100143ea03d003ec01200418e00943b600000419200807fbb9a14419000dc39e000017ebfab7839c000007e2ed2147fa5eb787e268b787f84e3787e4903a67fc3f3783bff00204e8004217e268b787c701b787fa5eb787f84e3787fc3f3787ee903a64e80042135efffff91dfffe839ceffff921fffec907ffff0931fffe0937fffe493f600004082ffa48121000c7eb54a143b7b00017c14d8004082ff78812100103b18ffff3b9cffff7c09c0004082ff5c81c1002081e100248201002882c1004082e1004483010048836100548381005883a1005c4190fd2c41a8fd7c82a1003c4bfffd243b6000014bfffc603b6000014bfffdcc81e100144bffff283ea03d00418a014441aefcfc91c1002091e100249201002892c1004092e1004493010048936100549381005893a1005c419000fc39e00000812100083e4002543ec0025439ef00207d2900d06252ccac9121000862d6d8003ae000003e0012003b0000004192007c7dd89a144190009c3b6000017ebfab783ba000007e3dd2147dc573787e268b787f24cb787e4903a67fc3f3783bff00204e8004217e268b787c7c1b787dc573787f24cb787fc3f3787ec903a64e800421377bffff93bfffe83bbdffff939fffec907ffff092ffffe0931fffe493f000004082ffa47eb57a143b1800017c14c0004181ff7c812100103af700013b3900017c09b80040a1fd503b0000004bffff60836100084bffff6839e000004bfffaf83ea03d004092fbe84bfffee439e000004bfffc68812100087d2f48f855ef28344bffff007d3048f8561028344bfffd9440b1fe9082a1003c4bfffbb860000000";
			MainForm.GeckoU.makeAssembly(59864492u, input);
			MainForm.GeckoU.CallFunction64(59864492u, new uint[1]);
			MainForm.GeckoU.WriteUInt(301989904u, MainForm.GeckoU.PeekUInt(301989888u));
			MainForm.GeckoU.WriteUInt(52053236u, 1223015176u);
			//From MamiesMod V4 (to lazy to convert)
		}

		private void executeGiveItem()
		{
			string input = "9421ff887c0802a63ce031003d0031009001007c3d4031003d20310093c10070610802143bc00000614a02186129021c60e70210934100609381006893a1006c93e100743fe0109c80e7000063ffd8e48349000083a80000838a000093c1005493610064813f000093c1005081290034812900f8812900c87f69382e480000110067006900760065000000007c8802a63d20020b38610008612908d47d2903a64e8004213d20024661290e54814100107d2903a681210014800100187f47d378808100087f86e3788061000c7fa5eb788161001c3901002891410030912100348141002081210024900100389361004893c1004c90810028388100489061002c386100509161003c91410040912100444e800421811f0000814100503d200304810800346129a5d88161005438810058806808787d2903a6914100589161005c4e8004218001007c83410060836100647c0803a68381006883a1006c83c1007083e10074382100784e80002060000000";
			MainForm.GeckoU.makeAssembly(0x039156C0, input);
			MainForm.GeckoU.CallFunction(0x039156C0, new uint[1]);
		}
		#endregion

		#region Mods
		private void Flying_CheckedChanged(object sender, EventArgs e)
		{
			try
			{
				MainForm.GeckoU.WriteUIntToggle(0x0271AA74, on, 0x7FE3FB78, Flying.Checked);
			}
			catch
			{
				codeErr();
			}
		}
		private void noTeleport_CheckedChanged(object sender, EventArgs e)
		{
			MainForm.GeckoU.WriteUIntToggle(0x0336367C, blr, 0x9421FED0, noTeleport.Checked);
		}

		private void playersNeeded_ValueChanged(object sender, EventArgs e)
		{
			try
			{
				MainForm.GeckoU.WriteUInt(0x2C7C004, MainForm.GeckoU.Mix((uint)0x38600000, playersNeeded.Value));
			}
			catch
			{
				codeErr();
			}
		}

		private void aimbotBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			try
			{
				switch (aimbotBox.SelectedIndex)
				{
					case 0:
						MainForm.GeckoU.WriteUInt(0x4000264, 0x60000000);
						return;

					case 1:
						MainForm.GeckoU.WriteUInt(0x4000264, 0x60000000);
						MainForm.GeckoU.WriteUInt(0x40008B8, 0x80A400C8);
						MainForm.GeckoU.WriteUInt(0x40008BC, 0x80C400CC);
						MainForm.GeckoU.WriteUInt(0x4000264, 0x48000614);
						return;

					case 2:
						MainForm.GeckoU.WriteUInt(0x4000264, 0x60000000);
						MainForm.GeckoU.WriteUInt(0x40008B8, 0x80A40038);
						MainForm.GeckoU.WriteUInt(0x40008BC, 0x80C4003C);
						MainForm.GeckoU.WriteUInt(0x4000B68, 0x80840038);
						MainForm.GeckoU.WriteUInt(0x4000264, 0x48000614);
						return;
				}
			}
			catch
			{
				codeErr();
			}
		}

		private void chestRefillTime_ValueChanged(object sender, EventArgs e)
		{
			try
			{
				MainForm.GeckoU.WriteUInt(0x2C5CC74, MainForm.GeckoU.Mix((uint)0x38600000, chestRefillTime.Value));
			}
			catch
			{
				codeErr();
			}
		}

		private void noMovementRestriction_Click(object sender, EventArgs e)
		{
			try
			{
				uint num = MainForm.GeckoU.PeekUInt(MainForm.GeckoU.PeekUInt(0x10A0A614) + 0xD4);
				num += 0x814;
				MainForm.GeckoU.WriteUInt(num, 0x0);
			}
			catch
			{
				codeErr();
			}
		}

		private void fastAttack_CheckedChanged(object sender, EventArgs e)
		{
			try
			{
				MainForm.GeckoU.WriteUIntToggle(0x108E0C8C, 0x3E803E6A, 0xBE800000, fastAttack.Checked);
			}
			catch
			{
				codeErr();
			}
		}

		private void SpamBow_CheckedChanged(object sender, EventArgs e)
		{
			try
			{
				MainForm.GeckoU.WriteUIntToggle(0x02162F04, 0x3BE00001, 0x3BE00014, SpamBow.Checked);
			}
			catch
			{
				codeErr();
			}
		}

		private void guna2CheckBox4_CheckedChanged(object sender, EventArgs e)
		{
			try
			{
				MainForm.GeckoU.WriteUIntToggle(0x108E0C8C, 0xBE800000, 0x3E800000, FastZR.Checked);
			}
			catch
			{
				codeErr();
			}
		}

		private void XRay_CheckedChanged(object sender, EventArgs e)
		{
			try
			{
				MainForm.GeckoU.WriteUIntToggle(0x030E4924, 0x38800000, 0x38800001, XRay.Checked);
			}
			catch
			{
				codeErr();
			}
		}

		private void SeeNNID_CheckedChanged(object sender, EventArgs e)
		{
			try
			{
				MainForm.GeckoU.WriteUIntToggle(0x031B2B4C, this.on, 0x5403063E, SeeNNID.Checked);
			}
			catch
			{
				codeErr();
			}
		}

		private void creative_CheckedChanged(object sender, EventArgs e)
		{
			try
			{
				MainForm.GeckoU.WriteUIntToggle(0x02456F4C, this.on, 0x5403063E, creative.Checked);
			}
			catch
			{
				codeErr();
			}
		}

		private void unlockAllPermissions_CheckedChanged(object sender, EventArgs e)
		{
			try
			{
				MainForm.GeckoU.WriteUIntToggle(0x02C57E94, this.on, 0x57E3063E, unlockAllPermissions.Checked);
				MainForm.GeckoU.WriteUIntToggle(0x02C57E34, this.on, 0x57E3063E, unlockAllPermissions.Checked);
				MainForm.GeckoU.WriteUIntToggle(0x02C51C20, this.on, 0x57E3063E, unlockAllPermissions.Checked);
				MainForm.GeckoU.WriteUIntToggle(0x02C5CC84, this.on, 0x88630124, unlockAllPermissions.Checked);
				MainForm.GeckoU.WriteUIntToggle(0x02C57D74, this.on, 0x57E3063E, unlockAllPermissions.Checked);
				MainForm.GeckoU.WriteUIntToggle(0x02C57DD4, this.on, 0x57E3063E, unlockAllPermissions.Checked);
				MainForm.GeckoU.WriteUIntToggle(0x02C5EED8, this.off, this.on, unlockAllPermissions.Checked);
			}
			catch
			{
				codeErr();
			}
		}

		private void tntExplodes_CheckedChanged(object sender, EventArgs e)
		{
			try
			{
				MainForm.GeckoU.WriteUIntToggle(0x2C59E04, on, off, tntExplodes.Checked);
			}
			catch
			{
				codeErr();
			}
		}

		private void hsotOptions_CheckedChanged(object sender, EventArgs e)
		{
			try
			{
				MainForm.GeckoU.WriteUIntToggle(0x10A2B3B4, 0xBE81C6A8, 0xEA801C8B, hsotOptions.Checked);
			}
			catch
			{
				codeErr();
			}
		}

		private void noKillBarrier_CheckedChanged(object sender, EventArgs e)
		{
			try
			{
				MainForm.GeckoU.WriteUIntToggle(0x2C7DD38, off, on, noKillBarrier.Checked);
			}
			catch
			{
				codeErr();
			}
		}

		private void damagePlayers_CheckedChanged(object sender, EventArgs e)
		{
			try
			{
				MainForm.GeckoU.WriteUIntToggle(0x2C7DDD0, on, off, damagePlayers.Checked);
			}
			catch
			{
				codeErr();
			}
		}

		private void gameDoesntEnd_CheckedChanged(object sender, EventArgs e)
		{
			try
			{
				MainForm.GeckoU.WriteUIntToggle(0x02C9554C, off, on, gameDoesntEnd.Checked);
			}
			catch
			{
				codeErr();
			}
		}

		private void seeHUD_CheckedChanged(object sender, EventArgs e)
		{
			try
			{
				MainForm.GeckoU.WriteUIntToggle(0x02C5EED0, 0x540E063E, 0x5403063E, seeHUD.Checked);
			}
			catch
			{
				codeErr();
			}
		}

		private void UnlockAllAchivements_CheckedChanged(object sender, EventArgs e)
		{
			try
			{
				if (UnlockAllAchivements.Checked)
				{
					MainForm.GeckoU.WriteUInt(MainForm.GeckoU.PeekUInt(MainForm.GeckoU.PeekUInt(0x109CED18) + 0x4C4) + 0x19, uint.MaxValue);
					MainForm.GeckoU.WriteUInt(MainForm.GeckoU.PeekUInt(MainForm.GeckoU.PeekUInt(0x109CED18) + 0x4C4) + 0x1D, uint.MaxValue);
					MainForm.GeckoU.WriteUInt(MainForm.GeckoU.PeekUInt(MainForm.GeckoU.PeekUInt(0x109CED18) + 0x4C4) + 0x21, uint.MaxValue);
				}
				else
				{
					MainForm.GeckoU.WriteUInt(MainForm.GeckoU.PeekUInt(MainForm.GeckoU.PeekUInt(0x109CED18) + 0x4C4) + 0x19, 0x0);
					MainForm.GeckoU.WriteUInt(MainForm.GeckoU.PeekUInt(MainForm.GeckoU.PeekUInt(0x109CED18) + 0x4C4) + 0x1D, 0x0);
					MainForm.GeckoU.WriteUInt(MainForm.GeckoU.PeekUInt(MainForm.GeckoU.PeekUInt(0x109CED18) + 0x4C4) + 0x21, 0x0);
				}
			}
			catch
			{
				codeErr();
			}
		}

		private void devMode_CheckedChanged(object sender, EventArgs e)
		{
			try
			{
				MainForm.GeckoU.WriteUIntToggle(0x02F5C874, on, off, devMode.Checked);
			}
			catch
			{
				codeErr();
			}
		}

		private void DisableTotems_CheckedChanged(object sender, EventArgs e)
		{
			try
			{
				MainForm.GeckoU.WriteUIntToggle(0x257B724, blr, 0x7C0802A6, DisableTotems.Checked);
			}
			catch
			{
				codeErr();
			}
		}

		private void CanWritePOnsSign_CheckedChanged(object sender, EventArgs e)
		{
			try
			{
				MainForm.GeckoU.WriteUIntToggle(0x2F88110, 0x39400002, 0x39400003, CanWritePOnsSign.Checked);
			}
			catch
			{
				codeErr();
			}
		}

		private void AllDlc_CheckedChanged(object sender, EventArgs e)
		{
			try
			{
				MainForm.GeckoU.WriteUIntToggle(0x02AE8B30, on, 0x7FE3FB78, AllDlc.Checked);
				MainForm.GeckoU.WriteUIntToggle(0x02AEF828, on, 0x7FE3FB78, AllDlc.Checked);
			}
			catch
			{
				codeErr();
			}
		}

		private void FriendOfFriendBypass_CheckedChanged(object sender, EventArgs e)
		{
			try
			{
				MainForm.GeckoU.WriteULongToggle(0x02D5731C, 0x386000014E800020, 0x7C0802A69421FFF0, FriendOfFriendBypass.Checked);
			}
			catch
			{
				codeErr();
			}
		}

		private void AllwaysTakeAll_CheckedChanged(object sender, EventArgs e)
		{
			try
			{
				MainForm.GeckoU.WriteUIntToggle(0x02DEC0B4, on, 0x57E3063E, AllwaysTakeAll.Checked);
			}
			catch
			{
				codeErr();
			}
		}

		private void SeeChatInActionbar_CheckedChanged(object sender, EventArgs e)
		{
			try
			{
				MainForm.GeckoU.WriteUIntToggle(0x0305d384, 0x41820038, nop, SeeChatInActionbar.Checked);
				MainForm.GeckoU.WriteUIntToggle(0x0305d364, 0x41820058, nop, SeeChatInActionbar.Checked);
				MainForm.GeckoU.WriteUIntToggle(0x0305d384, nop, 0x41820038, SeeChatInActionbar.Checked);
				MainForm.GeckoU.WriteUIntToggle(0x0305d364, nop, 0x41820058, SeeChatInActionbar.Checked);
			}
			catch
			{
				codeErr();
			}
		}

		private void SeeArmorOnSide_CheckedChanged(object sender, EventArgs e)
		{
			try
			{
				MainForm.GeckoU.WriteUIntToggle(0x02E9B1B0, 0x7FE4FB78, 0x7FC4F378, SeeArmorOnSide.Checked);
			}
			catch
			{
				codeErr();
			}
		}

		private void Speed_CheckedChanged(object sender, EventArgs e)
		{
			try
			{
				MainForm.GeckoU.WriteUIntToggle(0x1066ACC8, 0x3F56AD89, 0x3E26AD89, Speed.Checked);
			}
			catch
			{
				codeErr();
			}
		}

		private void GodMode_CheckedChanged(object sender, EventArgs e)
		{
			try
			{
				MainForm.GeckoU.WriteUIntToggle(0x2727824, 0xFC80F890, 0xFC20F890, GodMode.Checked);
			}
			catch
			{
				codeErr();
			}
		}

		private void DualAny_CheckedChanged(object sender, EventArgs e)
		{
			try
			{
				MainForm.GeckoU.WriteUIntToggle(0x2F59534, 0x480002E8, 0x7C0802A6, fullCrafting.Checked);
			}
			catch
			{
				codeErr();
			}
		}

		private void SeeHitbox_CheckedChanged(object sender, EventArgs e)
		{
			try
			{
				uint num = MainForm.GeckoU.PeekUInt(MainForm.GeckoU.PeekUInt(0x10A72A94) + 0xC0);
				MainForm.GeckoU.WriteUIntToggle(num + 0x90, 0x1F000, 0x100000, SeeHitbox.Checked);
			}
			catch
			{
				codeErr();
			}
		}

		private void unlockLobbySpec_CheckedChanged(object sender, EventArgs e)
		{
			try
			{
				if (this.unlockLobbySpec.Checked)
				{
					uint address = MainForm.GeckoU.PeekUInt(MainForm.GeckoU.PeekUInt(0x109C4CEC) + 0x4C);
					MainForm.GeckoU.WriteUInt(address, 0x5);
					return;
				}
				else
				{
					uint address2 = MainForm.GeckoU.PeekUInt(MainForm.GeckoU.PeekUInt(0x109C4CEC) + 0x4C);
					MainForm.GeckoU.WriteUInt(address2, 0x2);
				}
			}
			catch
			{
				codeErr();
			}
		}

		private void BunnyHop_CheckedChanged(object sender, EventArgs e)
		{
			try
			{
				uint num2 = MainForm.GeckoU.PeekUInt(MainForm.GeckoU.PeekUInt(0x10A0A624) + 0x9C);
				num2 += 0x734;
				MainForm.GeckoU.WriteUIntToggle(num2, 0x3EA3D70A, 0x3CA3D70A, BunnyHop.Checked);
			}
			catch
			{
				codeErr();
			}
		}

		private void ClimbWalls_CheckedChanged(object sender, EventArgs e)
		{
			try
			{
				MainForm.GeckoU.WriteUIntToggle(0x257DF90, this.on, off, ClimbWalls.Checked);
			}
			catch
			{
				codeErr();
			}
		}

		private void NoClip_CheckedChanged(object sender, EventArgs e)
		{
			try
			{
				if (NoClip.Checked)
				{
					uint num = MainForm.GeckoU.PeekUInt(MainForm.GeckoU.PeekUInt(0x10A0A624) + 0x9C);
					MainForm.GeckoU.WriteUInt(num + 0x1DC, 0x10000000);
				}
				else
				{
					uint num2 = MainForm.GeckoU.PeekUInt(MainForm.GeckoU.PeekUInt(278963748u) + 0x9C);
					MainForm.GeckoU.WriteUInt(num2 + 0x1DC, 0x00000000);
				}
			}
			catch
			{
				codeErr();
			}
		}

		private void FastSmelt_CheckedChanged(object sender, EventArgs e)
		{
			try
			{
				MainForm.GeckoU.WriteUIntToggle(0x23F66A4, on, off, FastSmelt.Checked);
			}
			catch
			{
				codeErr();
			}
		}

		private void Fullbright_CheckedChanged(object sender, EventArgs e)
		{
			try
			{
				MainForm.GeckoU.WriteUIntToggle(0x108C7C2C, nop, 0x3CF5C28F, Fullbright.Checked);
			}
			catch
			{
				codeErr();
			}
		}

		private void EatRun_CheckedChanged(object sender, EventArgs e)
		{
			try
			{
				MainForm.GeckoU.WriteUIntToggle(0x108E0E60, 0x3FFFFFFF, 0x3E4CCCCD, EatRun.Checked);
			}
			catch
			{
				codeErr();
			}
		}

		private void NoFallDamage_CheckedChanged(object sender, EventArgs e)
		{
			try
			{
				MainForm.GeckoU.WriteUIntToggle(0x10665EF0, 0x459C4000, 0x40400000, NoFallDamage.Checked);
			}
			catch
			{
				codeErr();
			}
		}

		private void breathUnderwater_CheckedChanged(object sender, EventArgs e)
		{
			try
			{
				MainForm.GeckoU.WriteUIntToggle(0x2572AA4, this.blr, this.mflr, breathUnderwater.Checked);
			}
			catch
			{
				codeErr();
			}
		}

		private void noKnock_CheckedChanged(object sender, EventArgs e)
		{
			try
			{
				MainForm.GeckoU.WriteUIntToggle(0x257D85C, this.blr, 0x9421FFA8, noKnock.Checked);
			}
			catch
			{
				codeErr();
			}
		}

		private void exKnock_CheckedChanged(object sender, EventArgs e)
		{
			try
			{
				MainForm.GeckoU.WriteUIntToggle(0x0257D980, 0xFC00E838, 0xFC006378, exKnock.Checked);
				MainForm.GeckoU.WriteUIntToggle(0x0257D990, 0xFD20B890, 0xFD290372, exKnock.Checked);
			}
			catch
			{
				codeErr();
			}
		}

		private void placeBlocksHead_CheckedChanged(object sender, EventArgs e)
		{
			try
			{
				MainForm.GeckoU.WriteUIntToggle(0x0207F604, this.on, 0x7FC3F378, placeBlocksHead.Checked);
			}
			catch
			{
				codeErr();
			}
		}

		private void craftEvery_CheckedChanged(object sender, EventArgs e)
		{
			try
			{
				MainForm.GeckoU.WriteUIntToggle(0x02F70970, on, off, craftEvery.Checked);
			}
			catch
			{
				codeErr();
			}
		}

		private void InfinateItems_CheckedChanged(object sender, EventArgs e)
		{
			try
			{
				MainForm.GeckoU.WriteUIntToggle(0x24872AC, on, 0x3D800248, InfinateItems.Checked);
				MainForm.GeckoU.WriteUIntToggle(0x24872B0, blr, 0x398C7294, InfinateItems.Checked);
			}
			catch
			{
				codeErr();
			}
		}

		private void waterFly_CheckedChanged(object sender, EventArgs e)
		{
			try
			{
				MainForm.GeckoU.WriteUIntToggle(0x0255E81C, 0x38000001, 0x38000000, waterFly.Checked);
			}
			catch
			{
				codeErr();
			}
		}

		private void JumpAir_CheckedChanged(object sender, EventArgs e)
		{
			try
			{
				MainForm.GeckoU.WriteUIntToggle(0x0232F3A0, 0x38800001, 0x38800000, JumpAir.Checked);
			}
			catch
			{
				codeErr();
			}
		}

		private void unlimitedThings_CheckedChanged(object sender, EventArgs e)
		{
			try
			{
				MainForm.GeckoU.WriteUIntToggle(0x2173790, 0x38800000, 0x38800001, unlimitedThings.Checked);
				MainForm.GeckoU.WriteUIntToggle(0x241467C, 0x38800000, 0x38800001, unlimitedThings.Checked);
				MainForm.GeckoU.WriteUIntToggle(0x21643CC, 0x38800000, 0x38800001, unlimitedThings.Checked);
			}
			catch
			{
				codeErr();
			}
		}

		private void fasterActions_CheckedChanged(object sender, EventArgs e)
		{
			try
			{
				if (fasterActions.Checked)
				{
					uint address = MainForm.GeckoU.PeekUInt(MainForm.GeckoU.PeekUInt(0x109CD8E4) + 0x20);
					MainForm.GeckoU.WriteUInt(address, 0x41F00005);
					return;
				}
				else
				{
					uint address2 = MainForm.GeckoU.PeekUInt(MainForm.GeckoU.PeekUInt(0x109CD8E4) + 0x20);
					MainForm.GeckoU.WriteUInt(address2, 0x41A00000);
				}
			}
			catch
			{
				codeErr();
			}
		}

		private void ripditeMode_CheckedChanged(object sender, EventArgs e)
		{
			try
			{
				MainForm.GeckoU.WriteUIntToggle(0x31F5484, 0x38630A08, 0x88630A08, ripditeMode.Checked);
			}
			catch
			{
				codeErr();
			}
		}

		private void NoUnderwaterFog_CheckedChanged(object sender, EventArgs e)
		{
			try
			{
				MainForm.GeckoU.WriteUIntToggle(0x0253C3CC, off, 0x88630011, NoUnderwaterFog.Checked);
			}
			catch
			{
				codeErr();
			}
		}

		private void killAura_CheckedChanged(object sender, EventArgs e)
		{
			try
			{
				MainForm.GeckoU.WriteUIntToggle(0x105DCCE0, 0xC0000000, 0x0, killAura.Checked);
			}
			catch
			{
				codeErr();
			}
		}

		private void commandsInMinigames_CheckedChanged(object sender, EventArgs e)
		{
			try
			{
				MainForm.GeckoU.WriteUIntToggle(0x022F0774, 0x38600000, 0x38600002, commandsInMinigames.Checked);
				MainForm.GeckoU.WriteUIntToggle(0x0245FC9C, 0x38600000, 0x38600002, commandsInMinigames.Checked);
				MainForm.GeckoU.WriteUIntToggle(0x02520964, 0x38600000, 0x38600002, commandsInMinigames.Checked);
				MainForm.GeckoU.WriteUIntToggle(0x029F8FE0, 0x38600000, 0x38600002, commandsInMinigames.Checked);
				MainForm.GeckoU.WriteUIntToggle(0x029FFE60, 0x38600000, 0x38600002, commandsInMinigames.Checked);
			}
			catch
			{
				codeErr();
			}
		}


		private void muteMic_CheckedChanged(object sender, EventArgs e)
		{
			try
			{
				GeckoU.WriteUIntToggle(0x10997EA8, 0x30000000, 0x3F000000, muteMic.Checked);
			}
			catch
			{
				codeErr();
			}
		}

		private void multiShot_Click(object sender, EventArgs e)
		{
			string input = "9421ff687c0802a69001009c936100843f60109c637bd8e491e10054813b00009221005c8129003492e1007481e900548229005882e9005c392f0002912100443931ffff912100483937ffff91c100503dc0028a924100603e408000926100643e60109c928100683e80028a92a1006c3ea0028b934100803f40030493c100903fc059809201005863de000492c10070625200019301007861ced6c4938100883a31000293e100943af7000291210040635aa5d89321007c627346a493a1008c3b2fffff6294ec5c62b52b8c3fa0433081e100483ed9800083e100403f0f800093a100303d3f800092c1003438a0000093e1001038800000c82100307dc903a693c1003038600000932100083b800000c00100303bff000193a100289301002cfc21002891e1000cc841002893c10028c001002893a1002091210024fc420028c881002093c10020c001002093a100189241001cfc840028c861001893c10018c0010018fc6300284e800421813b0000388100387f4903a68129003481290878906100389381003c7d234b784e80042180d3000038e0000038a10008388000057e8903a6386000004e800421388000007c701b787ea903a6386000004e800421811b0000388100387f4903a68108003481080878906100389381003c7d0343784e800421811b0000388100387f4903a68108003480680878920100389381003c4e8004217c17f8404082fed839ef00017c1178404082fec4812100443b3900017c1948404082feac8001009c81c1005081e100547c0803a6820100588221005c82410060826100648281006882a1006c82c1007082e10074830100788321007c83410080836100848381008883a1008c83c1009083e10094382100984e800020";
			MainForm.GeckoU.makeAssembly(0x03917010, input);
			MainForm.GeckoU.CallFunction(0x03917010, new uint[1]);
		}

		private void changeNNIDBtn_Click(object sender, EventArgs e)
		{
			try
			{
				uint num = MainForm.GeckoU.PeekUInt(0x10AD1C58);
				num += 0x4C;
				MainForm.GeckoU.WriteUInt(num, 0x0);
				uint num2 = MainForm.GeckoU.PeekUInt(0x10AD1C58);
				num2 += 0x50;
				MainForm.GeckoU.WriteUInt(num2, 0x0);
				uint num3 = MainForm.GeckoU.PeekUInt(0x10AD1C58);
				num3 += 0x54;
				MainForm.GeckoU.WriteUInt(num3, 0x0);
				uint num4 = MainForm.GeckoU.PeekUInt(0x10AD1C58);
				num4 += 0x58;
				MainForm.GeckoU.WriteUInt(num4, 0x0);
				uint num5 = MainForm.GeckoU.PeekUInt(0x10AD1C58);
				num5 += 0x5C;
				MainForm.GeckoU.WriteUInt(num5, 0x0);
				uint num6 = MainForm.GeckoU.PeekUInt(0x10AD1C58);
				num6 += 0x60;
				MainForm.GeckoU.WriteUInt(num6, 0x0);
				uint num7 = MainForm.GeckoU.PeekUInt(0x10AD1C58);
				num7 += 0x64;
				MainForm.GeckoU.WriteUInt(num7, 0x0);
				uint num8 = MainForm.GeckoU.PeekUInt(0x10AD1C58);
				num8 += 0x68;
				MainForm.GeckoU.WriteUInt(num8, 0x0);
				uint num9 = MainForm.GeckoU.PeekUInt(0x10AD1C58);
				num9 += 0x6C;
				MainForm.GeckoU.WriteUInt(num9, 0x0);
				uint num10 = MainForm.GeckoU.PeekUInt(0x10AD1C58);
				num10 += 0x70;
				MainForm.GeckoU.WriteUInt(num10, 0x0);
				uint num11 = MainForm.GeckoU.PeekUInt(0x10AD1C58);
				num11 += 0x74;
				MainForm.GeckoU.WriteUInt(num11, 0x0);
				uint num12 = MainForm.GeckoU.PeekUInt(0x10AD1C58);
				num12 += 0x78;
				MainForm.GeckoU.WriteUInt(num12, 0x0);
				uint num13 = MainForm.GeckoU.PeekUInt(0x10AD1C58);
				num13 += 0x7C;
				MainForm.GeckoU.WriteUInt(num13, 0x0);
				uint num14 = MainForm.GeckoU.PeekUInt(0x10AD1C58);
				num14 += 0x80;
				MainForm.GeckoU.WriteUInt(num14, 0x0);
				this.gck();
				uint num15 = MainForm.GeckoU.PeekUInt(0x10AD1C58);
				this.String_poke(checked(num15 + 0x4E), " " + MainForm.smethod_4(nnidTest));
			}
			catch
			{
				codeErr();
			}
		}
		#endregion

		#region World Edit
		private void guna2Button1_Click_1(object sender, EventArgs e)
		{
			try
            {
				uint num = MainForm.GeckoU.PeekUInt(MainForm.GeckoU.PeekUInt(MainForm.GeckoU.PeekUInt(0x109CD8E4) + 0x34) + 0x54);
				uint num2 = MainForm.GeckoU.PeekUInt(MainForm.GeckoU.PeekUInt(MainForm.GeckoU.PeekUInt(0x109CD8E4) + 0x34) + 0x58);
				uint num3 = MainForm.GeckoU.PeekUInt(MainForm.GeckoU.PeekUInt(MainForm.GeckoU.PeekUInt(0x109CD8E4) + 0x34) + 0x5C);


				if (num > 0xFFFF)
				{
					num = uint.MaxValue + num;
					num = uint.MaxValue - num;
					this.startX.Value = (int)(0x0 - num);
				}
				else
				{
					this.startX.Value = num;
				}

				if (num2 > 0xFFFF)
				{
					num2 = uint.MaxValue + num2;
					num2 = uint.MaxValue - num2;
					this.startY.Value = (int)(0x0 - (num2 - 0x1));
				}
				else
				{
					this.startY.Value = num2 - 0x1;
				}

				if (num3 > 0xFFFF)
				{
					num3 = uint.MaxValue + num3;
					num3 = uint.MaxValue - num3;
					this.startZ.Value = (int)(0x0 - num3);
				}
				else
				{
					this.startZ.Value = num3;
				}
			}
			catch
            {
				codeErr();
            }
		}

		private void getEnd_Click(object sender, EventArgs e)
		{
			try
			{
				uint num = MainForm.GeckoU.PeekUInt(MainForm.GeckoU.PeekUInt(MainForm.GeckoU.PeekUInt(0x109CD8E4) + 0x34) + 0x54);
				uint num2 = MainForm.GeckoU.PeekUInt(MainForm.GeckoU.PeekUInt(MainForm.GeckoU.PeekUInt(0x109CD8E4) + 0x34) + 0x58);
				uint num3 = MainForm.GeckoU.PeekUInt(MainForm.GeckoU.PeekUInt(MainForm.GeckoU.PeekUInt(0x109CD8E4) + 0x34) + 0x5C);

				if (num > 0xFFFF)
				{
					num = uint.MaxValue + num;
					num = uint.MaxValue - num;
					this.endX.Value = (int)(0x0 - num);
				}
				else
				{
					this.endX.Value = num;
				}
				if (num2 > 0xFFFF)
				{
					num2 = uint.MaxValue + num2;
					num2 = uint.MaxValue - num2;
					this.endY.Value = (int)(0x0 - (num2 - 0x1));
				}
				else
				{
					this.endY.Value = num2 - 0x1;
				}
				if (num3 > 0xFFFF)
				{
					num3 = uint.MaxValue + num3;
					num3 = uint.MaxValue - num3;
					this.endZ.Value = (int)(0x0 - num3);
				}
				else
				{
					this.endZ.Value = num3;
				}
			}
			catch
			{
				codeErr();
			}
		}

		private void copyBuild_Click(object sender, EventArgs e)
		{
			try
			{
				MessageBox.Show("Copied Building!", "Copied!", MessageBoxButtons.OK, MessageBoxIcon.Information);
				executeGetBuildWithDamage();
			}
			catch
			{
				codeErr();
			}
		}

		private void pasteBuild_Click(object sender, EventArgs e)
		{
			try
			{
				uint value = MainForm.GeckoU.PeekUInt(MainForm.GeckoU.PeekUInt(MainForm.GeckoU.PeekUInt(0x109CD8E4) + 0x34) + 0x54);
				uint value2 = MainForm.GeckoU.PeekUInt(MainForm.GeckoU.PeekUInt(MainForm.GeckoU.PeekUInt(0x109CD8E4) + 0x34) + 0x58);
				uint value3 = MainForm.GeckoU.PeekUInt(MainForm.GeckoU.PeekUInt(MainForm.GeckoU.PeekUInt(0x109CD8E4) + 0x34) + 0x5C);
				MainForm.GeckoU.WriteUInt(0x3A100030, value);
				MainForm.GeckoU.WriteUInt(0x3A100034, value2);
				MainForm.GeckoU.WriteUInt(0x3A100038, value3);
				executeSetBuildWithDamage();
			}
			catch
			{
				codeErr();
			}
		}

		private void destroyBtn_Click(object sender, EventArgs e)
		{
			try
			{
				switch (nukerType.SelectedIndex)
				{
					case 0:
						string input = "9421ff603d2030126129303092e1007c82e90000938100903f80109c7d5700d0639cd8e4813c00007c17500091c10058812900349201006092a100749141004482a9005481c900588209005c418002507d3770507c0802a6912100507d37805091e1005c3de0028a9261006c3e608000932100843f20109c934100883f40028a9361008c3f60030493c100983fc05980900100a47eb7a8509221006463de000492410068627300019281007061efd6c492c10078637ba5d893010080633946a493a10094635aec5c93e1009c3dc04330912100489141004c812100443e958000830100509121004083e100483ed880008201004491c100303d5f80009281003438a0000093e1001038800000c82100307de903a693c100303860000092a100083ba00000c00100303a10000191c100283bff000192c1002cfc2100289301000cc841002893c10028c001002891c1002091410024fc420028c881002093c10020c001002091c100189261001cfc840028c861001893c10018c0010018fc6300284e800421815c0000388100387f6903a6814a0034814a08789061003893a1003c7d4353784e80042180d9000038e0000038a10008388000007f4903a6386000004e80042180d9000038a100087c721b7838e00000388000027f4903a6386000004e80042180fc0000388100387f6903a680e700347c711b78806708789241003893a1003c4e800421811c0000388100387f6903a681080034806808789221003893a1003c4e8004217c1780004080fec8812100403b180001392900017c174800912100404080fea48121004c3ab50001392900017c1748009121004c4080fe7c800100a481e1005c822100647c0803a6824100688261006c8281007082c100788301008083210084834100888361008c83a1009483c1009883e1009c81c100588201006082a1007482e1007c83810090382100a04e800020";
						MainForm.GeckoU.makeAssembly(0x3916AD8, input);
						MainForm.GeckoU.makeAssembly(0x3916AD8, input);
						MainForm.GeckoU.CallFunction(0x3916AD8, new uint[1]);
						return;

					case 1:
						string input2 = "9421ff403d20301261293030938100b03f80109c639cd8e481290000815c000091e1007c814a0034810a005481ea00587ce940507d084a147c0740009101006c90e10040810a005c408003347d4978507cef4a147c0a380090e100587ce9405092c10098914100687ec949d690e100547d484a14408003187c075000408003107d4900d0924100885529083c3e408000912100607c0802a67d0838506249000191c100783dc0028a920100803e005980932100a43f20109c934100a83f40028a936100ac3f600304900100c4621000049221008461ced6c49261008c637ba5d892810090633946a492a10094635aec5c92e1009c3de04330930100a093a100b493c100b893e100bc914100709101005c91410064912100488121006483a100687d2949d691210050812100709121004c812100403d298000912100448121004c3f1d8000826100607fc949d6812100508221005c824100547fde4a147d3189d67d29f2147c1648004081017c814100443d32800091e1003038a000009141003438800000814100407dc903a6c821003038600000920100303be0000091410008c001003091e100289301002cfc21002893a1000cc84100289201002892410010c001002891e1002091210024fc42002881210048c881002092010020c001002091e100189121001cfc840028c861001892010018c0010018fc6300284e800421813c0000388100387f6903a681290034812908789061003893e1003c7d234b784e80042180d9000038e0000038a10008388000007f4903a6386000004e80042180d900007c751b7838e0000038a10008388000017f4903a6386000004e80042180d9000038e0000038a100087c771b78388000027f4903a6386000004e800421811c0000388100387f6903a6810800347c741b788068087892a1003893e1003c4e800421815c0000388100387f6903a6814a0034806a087892e1003893e1003c4e800421813c0000388100387f6903a681290034806908789281003893e1003c4e8004213673ffff3a5200013a3100014082fe6c8121004c3bbd0001392900019121004c812100587c1d48004082fe308121004039490001812100649141004039290001912100648121006c7c0a48004082fde8800100c481c10078820100807c0803a682210084824100888261008c8281009082a1009482c1009882e1009c830100a0832100a4834100a8836100ac83a100b483c100b883e100bc81e1007c838100b0382100c04e80002082c1009881e1007c838100b0382100c04e800020";
						MainForm.GeckoU.makeAssembly(0x3915000, input2);
						MainForm.GeckoU.CallFunction(0x3915000, new uint[0x1]);
						return;
				}
			}
			catch
			{
				codeErr();
			}
		}

		private void nukerSize_ValueChanged_1(object sender, EventArgs e)
		{
			try
			{
				MainForm.GeckoU.WriteUInt(0x30123030, MainForm.GeckoU.Mix(0x0, nukerSize.Value));
				MainForm.GeckoU.WriteUInt(0x30123040, MainForm.GeckoU.Mix(0x0, nukerSize.Value));
			}
			catch
			{
				codeErr();
			}
		}

		private void banMethode_ValueChanged(object sender, EventArgs e)
		{
			try
			{
				if (MainForm.smethod_8(MainForm.controlText_method(banMethode), "100"))
				{
					MainForm.GeckoU.WriteUInt(0x2D5731C, on);
					MainForm.GeckoU.WriteUInt(0x2D57320, blr);
					return;
				}
				uint num = MainForm.GeckoU.PeekUInt(MainForm.GeckoU.PeekUInt(0x101D1D58) + 0x84);
				num += 0x2C;
				MainForm.GeckoU.WriteUInt(0x2D5731C, 0x7C0802A6);
				MainForm.GeckoU.WriteUInt(0x2D57320, 0x9421FFF0);
				MainForm.GeckoU.WriteUInt(num, MainForm.GeckoU.Mix(off, banMethode.Value));
			}
			catch
			{
				codeErr();
			}
		}

		private void antikick_CheckedChanged(object sender, EventArgs e)
		{
			MainForm.GeckoU.WriteUIntToggle(0x03052720, blr, 0x9421FFD8, antikick.Checked);

		}

		#endregion

		#region Commands
		private void enchantBtn_Click(object sender, EventArgs e)
		{
			try
			{
				bool flag = this.enchantId.SelectedIndex == 0;
				if (flag)
				{
					this.enchantString = "00000000";
				}
				bool flag2 = this.enchantId.SelectedIndex == 1;
				if (flag2)
				{
					this.enchantString = "00000001";
				}
				bool flag3 = this.enchantId.SelectedIndex == 2;
				if (flag3)
				{
					this.enchantString = "00000002";
				}
				bool flag4 = this.enchantId.SelectedIndex == 3;
				if (flag4)
				{
					this.enchantString = "00000003";
				}
				bool flag5 = this.enchantId.SelectedIndex == 4;
				if (flag5)
				{
					this.enchantString = "00000004";
				}
				bool flag6 = this.enchantId.SelectedIndex == 5;
				if (flag6)
				{
					this.enchantString = "00000005";
				}
				bool flag7 = this.enchantId.SelectedIndex == 6;
				if (flag7)
				{
					this.enchantString = "00000006";
				}
				bool flag8 = this.enchantId.SelectedIndex == 7;
				if (flag8)
				{
					this.enchantString = "00000007";
				}
				bool flag9 = this.enchantId.SelectedIndex == 8;
				if (flag9)
				{
					this.enchantString = "00000008";
				}
				bool flag10 = this.enchantId.SelectedIndex == 9;
				if (flag10)
				{
					this.enchantString = "00000009";
				}
				bool flag11 = this.enchantId.SelectedIndex == 10;
				if (flag11)
				{
					this.enchantString = "00000010";
				}
				bool flag12 = this.enchantId.SelectedIndex == 11;
				if (flag12)
				{
					this.enchantString = "00000011";
				}
				bool flag13 = this.enchantId.SelectedIndex == 12;
				if (flag13)
				{
					this.enchantString = "00000012";
				}
				bool flag14 = this.enchantId.SelectedIndex == 13;
				if (flag14)
				{
					this.enchantString = "00000013";
				}
				bool flag15 = this.enchantId.SelectedIndex == 14;
				if (flag15)
				{
					this.enchantString = "00000014";
				}
				bool flag16 = this.enchantId.SelectedIndex == 15;
				if (flag16)
				{
					this.enchantString = "00000015";
				}
				bool flag17 = this.enchantId.SelectedIndex == 16;
				if (flag17)
				{
					this.enchantString = "00000020";
				}
				bool flag18 = this.enchantId.SelectedIndex == 17;
				if (flag18)
				{
					this.enchantString = "00000021";
				}
				bool flag19 = this.enchantId.SelectedIndex == 18;
				if (flag19)
				{
					this.enchantString = "00000022";
				}
				bool flag20 = this.enchantId.SelectedIndex == 19;
				if (flag20)
				{
					this.enchantString = "00000023";
				}
				bool flag21 = this.enchantId.SelectedIndex == 20;
				if (flag21)
				{
					this.enchantString = "00000030";
				}
				bool flag22 = this.enchantId.SelectedIndex == 21;
				if (flag22)
				{
					this.enchantString = "00000031";
				}
				bool flag23 = this.enchantId.SelectedIndex == 22;
				if (flag23)
				{
					this.enchantString = "00000032";
				}
				bool flag24 = this.enchantId.SelectedIndex == 23;
				if (flag24)
				{
					this.enchantString = "00000033";
				}
				bool flag25 = this.enchantId.SelectedIndex == 24;
				if (flag25)
				{
					this.enchantString = "0000003D";
				}
				bool flag26 = this.enchantId.SelectedIndex == 25;
				if (flag26)
				{
					this.enchantString = "0000003E";
				}
				bool flag27 = this.enchantId.SelectedIndex == 26;
				if (flag27)
				{
					this.enchantString = "00000041";
				}
				bool flag28 = this.enchantId.SelectedIndex == 27;
				if (flag28)
				{
					this.enchantString = "00000042";
				}
				bool flag29 = this.enchantId.SelectedIndex == 28;
				if (flag29)
				{
					this.enchantString = "00000043";
				}
				bool flag30 = this.enchantId.SelectedIndex == 29;
				if (flag30)
				{
					this.enchantString = "00000044";
				}
				bool flag31 = this.enchantId.SelectedIndex == 30;
				if (flag31)
				{
					this.enchantString = "00000046";
				}
				bool flag32 = this.enchantId.SelectedIndex == 31;
				if (flag32)
				{
					this.enchantString = "00000047";
				}
				MainForm.GeckoU.makeAssembly(0x10303008, enchantString);
				MainForm.GeckoU.WriteUInt(0x2081C9C, 0x38607FFF);
				MainForm.GeckoU.WriteUInt(0x2081D78, 0x38607FFF);
				MainForm.GeckoU.WriteUInt(0x2081E54, 0x38607FFF);
				MainForm.GeckoU.WriteUInt(0x2081FFC, 0x38607FFF);
				MainForm.GeckoU.WriteUInt(0x20A8BA0, 0x38607FFF);
				MainForm.GeckoU.WriteUInt(0x2278618, 0x38607FFF);
				MainForm.GeckoU.WriteUInt(0x22DDAC4, 0x38607FFF);
				MainForm.GeckoU.WriteUInt(0x22E0680, 0x38607FFF);
				MainForm.GeckoU.WriteUInt(0x22DB580, 0x38607FFF);
				MainForm.GeckoU.WriteUInt(0x2377B0C, 0x38607FFF);
				MainForm.GeckoU.WriteUInt(0x2426D84, 0x38607FFF);
				MainForm.GeckoU.WriteUInt(0x244A47C, 0x38607FFF);
				MainForm.GeckoU.WriteUInt(0x2510714, 0x38607FFF);
				MainForm.GeckoU.WriteUInt(0x25E6710, 0x38607FFF);
				MainForm.GeckoU.WriteUInt(0x261B3C0, 0x38607FFF);
				MainForm.GeckoU.WriteUInt(0x277EDEC, 0x38607FFF);
				MainForm.GeckoU.WriteUInt(0x27F2CCC, 0x38607FFF);
				MainForm.GeckoU.WriteUInt(0x29DE20C, 0x38607FFF);
				MainForm.GeckoU.WriteUInt(0x29F2474, 0x38607FFF);
				MainForm.GeckoU.WriteUInt(0x29F2F00, 0x38607FFF);
				MainForm.GeckoU.WriteUInt(0x29F3080, 0x38607FFF);
				MainForm.GeckoU.WriteUInt(0x29F31F8, 0x38607FFF);
				MainForm.GeckoU.WriteUInt(0x29F2D48, 0x38607FFF);
				MainForm.GeckoU.WriteUInt(0x2A61FD8, 0x38607FFF);
				MainForm.GeckoU.WriteUInt(0x2A62C94, 0x38607FFF);
				MainForm.GeckoU.WriteUInt(0x2AA824C, 0x38607FFF);
				MainForm.GeckoU.WriteUInt(0x22DB580, 0x38607FFF);
				MainForm.GeckoU.WriteUInt(0x1030300C, MainForm.GeckoU.Mix(0x0, this.enchantLevel.Value));
				MainForm.GeckoU.WriteUInt(0x10303010, 0x0);
				this.enchantText = string.Concat(new string[]
				{
				"Verus: Enchanted Item with ",
				this.enchantId.Text,
				" ",
				this.enchantLevel.Value.ToString(),
				" "
				});
				MainForm.GeckoU.clearString2(274445988u, 274446216u);
				MainForm.GeckoU.WriteStringUTF16(274445988u, this.enchantText);
				MainForm.GeckoU.makeAssembly(59867608u, "9421FFE87C0802A63D0010303D40103093E100143FE0031663FF68189001001C938100087FE903A693A1000C3D20103093C1001061083008614A300C6129301083C8000083AA0000838900004E800421808300342C0400004182006C3D20022F3C60103061291518390407407D2903A67F87E3787FA6EB787FC5F378606330004CC631824E8004217FE903A64E8004213D20031B61292654388000007D2903A64CC631824E8004213D2003046129A5D83C8010307D2903A6608430004CC631824E8004218001001C3D20010F61296AE08381000883A1000C7D2903A683C100107C0803A683E10014382100184E80002060000000");
				MainForm.GeckoU.CallFunction(59867608u, new uint[1]);
			}
			catch
			{
				codeErr();
			}

		}

		private void sendMsg_Click(object sender, EventArgs e)
		{
			try
            {
				MainForm.GeckoU.WriteUInt(0x31000214, 0x1);
				MainForm.GeckoU.WriteUInt(0x31000218, 0x0);
				MainForm.GeckoU.WriteUInt(0x3100021C, 0x0);
				MainForm.GeckoU.clearString2(0x1061F270, 0x1061F68C);
				MainForm.GeckoU.WriteStringUTF16(0x1061F270, EnterMessage.Text);
				this.executeGiveItem();
			}
			catch
            {
				codeErr();
            }
		}
		private void setTimeBtn_Click(object sender, EventArgs e)
		{
			try
			{
				byte[] Command = new byte[] { 0x94, 0x21, 0xFF, 0xE8, 0x7C, 0x08, 0x02, 0xA6, 0x3D, 0x00, 0x10, 0x30, 0x3D, 0x40, 0x10, 0x30, 0x93, 0xE1, 0x00,
				0x14, 0x3F, 0xE0, 0x03, 0x16, 0x63, 0xFF, 0x68, 0x18, 0x90, 0x01, 0x00, 0x1C, 0x93, 0x81, 0x00, 0x08, 0x7F, 0xE9, 0x03, 0xA6, 0x93, 0xA1,
				0x00, 0x0C, 0x3D, 0x20, 0x10, 0x30, 0x93, 0xC1, 0x00, 0x10, 0x61, 0x08, 0x30, 0x08, 0x61, 0x4A, 0x30, 0x0C, 0x61, 0x29, 0x30, 0x10, 0x83,
				0xC8, 0x00, 0x00, 0x83, 0xAA, 0x00, 0x00, 0x83, 0x89, 0x00, 0x00, 0x4E, 0x80, 0x04, 0x21, 0x80, 0x83, 0x00, 0x34, 0x2C, 0x04, 0x00, 0x00,
				0x41, 0x82, 0x00, 0x6C, 0x3D, 0x20, 0x02, 0x9F, 0x3C, 0x60, 0x10, 0x30, 0x61, 0x29, 0x92, 0xE0, 0x39, 0x04, 0x07, 0x40, 0x7D, 0x29, 0x03,
				0xA6, 0x7F, 0x87, 0xE3, 0x78, 0x7F, 0xA6, 0xEB, 0x78, 0x7F, 0xC5, 0xF3, 0x78, 0x60, 0x63, 0x30, 0x00, 0x4C, 0xC6, 0x31, 0x82, 0x4E, 0x80,
				0x04, 0x21, 0x7F, 0xE9, 0x03, 0xA6, 0x4E, 0x80, 0x04, 0x21, 0x3D, 0x20, 0x03, 0x1B, 0x61, 0x29, 0x26, 0x54, 0x38, 0x80, 0x00, 0x00, 0x7D,
				0x29, 0x03, 0xA6, 0x4C, 0xC6, 0x31, 0x82, 0x4E, 0x80, 0x04, 0x21, 0x3D, 0x20, 0x03, 0x04, 0x61, 0x29, 0xA5, 0xD8, 0x3C, 0x80, 0x10, 0x30,
				0x7D, 0x29, 0x03, 0xA6, 0x60, 0x84, 0x30, 0x00, 0x4C, 0xC6, 0x31, 0x82, 0x4E, 0x80, 0x04, 0x21, 0x80, 0x01, 0x00, 0x1C, 0x3D, 0x20, 0x01,
				0x0F, 0x61, 0x29, 0x6A, 0xE0, 0x83, 0x81, 0x00, 0x08, 0x83, 0xA1, 0x00, 0x0C, 0x7D, 0x29, 0x03, 0xA6, 0x83, 0xC1, 0x00, 0x10, 0x7C, 0x08,
				0x03, 0xA6, 0x83, 0xE1, 0x00, 0x14, 0x38, 0x21, 0x00, 0x18, 0x4E, 0x80, 0x00, 0x20, 0x60, 0x00, 0x00, 0x00 };

				MainForm.GeckoU.WriteUInt(0x10303008, 0x0);
				MainForm.GeckoU.WriteUInt(0x1030300C, (uint)int.Parse(settime.Text));
				MainForm.GeckoU.WriteUInt(0x10303010, 0x0);
				MainForm.GeckoU.WriteBytes(0x03B20000, Command);
				MainForm.GeckoU.CallFunction(0x03B20000, new uint[1]);
			}
			catch
			{
				codeErr();
			}
		}

		private void guna2TextBox1_TextChanged(object sender, EventArgs e)
		{

		}

		private void getPlayerInfoBtn_Click(object sender, EventArgs e)
		{
			try
            {
				executeUpdateWorldInfo();
			}
			catch
            {
				codeErr();
            }
		}

		private void giveItems_Click(object sender, EventArgs e)
		{
			try
            {
				bool flag9 = this.givePlayerBox.Text == "*Not Connected*";
				if (flag9)
				{
					MainForm.GeckoU.WriteUInt(822084112u, 0x0);
					this.giveText = string.Concat(new string[]
					{
						"Verus: Given Item (ID: ",
						this.giveItemID.Value.ToString(),
						") to ",
						this.givePlayerBox.Text,
						""
					});
				}
				bool flag11 = this.givePlayerBox.SelectedIndex == 0;
				if (flag11)
				{
					MainForm.GeckoU.WriteUInt(0x31000210, 0x0);
					this.giveText = string.Concat(new string[]
					{
						"Verus: Given Item (ID: ",
						this.giveItemID.Value.ToString(),
						") to ",
						this.givePlayerBox.Text,
						""
					});
				}
				bool flag12 = this.givePlayerBox.SelectedIndex == 1;
				if (flag12)
				{
					MainForm.GeckoU.WriteUInt(0x31000210, 0x8);
					this.giveText = string.Concat(new string[]
					{
						"Verus: Given Item (ID: ",
						this.giveItemID.Value.ToString(),
						") to ",
						this.givePlayerBox.Text,
						""
					});
				}
				bool flag13 = this.givePlayerBox.SelectedIndex == 2;
				if (flag13)
				{
					MainForm.GeckoU.WriteUInt(0x31000210, 0x10);
					this.giveText = string.Concat(new string[]
					{
						"Verus: Given Item (ID: ",
						this.giveItemID.Value.ToString(),
						") to ",
						this.givePlayerBox.Text,
						""
					});
				}
				bool flag14 = this.givePlayerBox.SelectedIndex == 3;
				if (flag14)
				{
					MainForm.GeckoU.WriteUInt(0x31000210, 0x18);
					this.giveText = string.Concat(new string[]
					{
						"Verus: Given Item (ID: ",
						this.giveItemID.Value.ToString(),
						") to ",
						this.givePlayerBox.Text,
						""
					});
				}
				bool flag15 = this.givePlayerBox.SelectedIndex == 4;
				if (flag15)
				{
					MainForm.GeckoU.WriteUInt(0x31000210, 0x20);
					this.giveText = string.Concat(new string[]
					{
						"Verus: Given Item (ID: ",
						this.giveItemID.Value.ToString(),
						") to ",
						this.givePlayerBox.Text,
						""
					});
				}
				bool flag16 = this.givePlayerBox.SelectedIndex == 5;
				if (flag16)
				{
					MainForm.GeckoU.WriteUInt(0x31000210, 0x28);
					this.giveText = string.Concat(new string[]
					{
						"Verus: Given Item (ID: ",
						this.giveItemID.Value.ToString(),
						") to ",
						this.givePlayerBox.Text,
						""
					});
				}
				bool flag17 = this.givePlayerBox.SelectedIndex == 6;
				if (flag17)
				{
					MainForm.GeckoU.WriteUInt(0x31000210, 0x30);
					this.giveText = string.Concat(new string[]
					{
						"Verus: Given Item (ID: ",
						this.giveItemID.Value.ToString(),
						") to ",
						this.givePlayerBox.Text,
						""
					});
				}
				bool flag18 = this.givePlayerBox.SelectedIndex == 7;
				if (flag18)
				{
					MainForm.GeckoU.WriteUInt(0x31000210, 0x38);
					this.giveText = string.Concat(new string[]
					{
						"Verus: Given Item (ID: ",
						this.giveItemID.Value.ToString(),
						") to ",
						this.givePlayerBox.Text,
						""
					});
				}
				MainForm.GeckoU.clearString2(0x1061F270, 0x1061F360);
				MainForm.GeckoU.WriteStringUTF16(0x1061F270, this.giveText);
				MainForm.GeckoU.WriteUInt(0x31000214, MainForm.GeckoU.Mix(0x0, this.giveItemID.Value));
				MainForm.GeckoU.WriteUInt(0x3100021C, MainForm.GeckoU.Mix(0x0, this.giveItemDamage.Value));
				MainForm.GeckoU.WriteUInt(0x31000218, MainForm.GeckoU.Mix(0x0, this.giveItemNumber.Value));
				this.executeGiveItem();
			}
			catch
            {
				codeErr();
            }
			#endregion
		}
    }
}
