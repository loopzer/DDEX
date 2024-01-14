#pragma once
#define NOMINMAX
#include <windows.h>
#include <intrin.h>

class Benaphore
{
private:
	LONG m_counter;
	HANDLE m_semaphore;

public:
	Benaphore()
	{
		m_counter = 0;
		m_semaphore = CreateSemaphore(NULL, 0, 1, NULL);
	}

	~Benaphore()
	{
		CloseHandle(m_semaphore);
	}

	void lock()
	{
		if (_InterlockedIncrement(&m_counter) > 1) // x86/64 guarantees acquire semantics
		{
			WaitForSingleObject(m_semaphore, INFINITE);
		}
	}

	void unlock()
	{
		if (_InterlockedDecrement(&m_counter) > 0) // x86/64 guarantees release semantics
		{
			ReleaseSemaphore(m_semaphore, 1, NULL);
		}
	}
};