#include "pch.h"

using namespace System;

#using "dll_gui.dll"

bool thread_finish = false;

void logging(Object^ parameter) {
	int value = -1;
	int prev_value = -1;
	dll_gui::UserControl1^ wnd = (dll_gui::UserControl1^)parameter;

	while (!thread_finish) {
		value = wnd->data_c->X;
		if (value != prev_value) {
			System::Console::WriteLine("value:" + value);
			prev_value = value;
		}
		System::Threading::Thread::Sleep(1000);
	}

	System::Console::WriteLine("Thread finish!");
}



[STAThreadAttribute]
int main(array<System::String ^> ^args)
{
	auto wnd = gcnew dll_gui::UserControl1();

	auto start = gcnew System::Threading::ParameterizedThreadStart(&logging);
	auto thread = gcnew System::Threading::Thread(start);
	thread->Start(wnd);

	wnd->ShowDialog();

	thread_finish = true;
	thread->Join();
    return 0;
}
