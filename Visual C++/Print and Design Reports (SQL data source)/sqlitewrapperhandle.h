//=============================================================================
//
//  Project: List & Label
//           Copyright (C) combit GmbH, All Rights Reserved
//
//  Authors: combit Software Team
//
//-----------------------------------------------------------------------------
//
//  List & Label  Sample Application
//
//=============================================================================
// sqlitewrapperhandle.h : 
// implementation of simple generic handle class as part of the  
// sqlite database wrapper template classes.
// Primary intention of these wrappers is to provide a modern c++11/14 style 
// interface to the sqlite database. 
// It is rather experimental and therefore neither feature complete nor considered stable 
// for production use yet.

#pragma once

// D:   Keine Unterstützung für constexpr und noexcept Schlüsselworte unter VS2015
// US:  No support for constexpr and noexcept keywords below VS2015
#if _MSC_VER < 1900
#undef _cmbt_constexpr_
#define _cmbt_constexpr_
#undef _cmbt_noexcept_
#define _cmbt_noexcept_
#else
#undef _cmbt_constexpr_
#define _cmbt_constexpr_ constexpr
#undef _cmbt_noexcept_
#define _cmbt_noexcept_ noexcept
#endif

#ifdef _DEBUG
#ifndef CMBTVERIFY
#define CMBTVERIFY _ASSERT
#endif
#ifndef CMBTVERIFY_
#define CMBTVERIFY_(result, expression) _ASSERT(result == expression)
#endif
#else
#ifndef CMBTVERIFY
#define CMBTVERIFY(expression) (expression)
#endif
#ifndef CMBTVERIFY_
#define CMBTVERIFY_(result, expression) (expression)
#endif
#endif

namespace cmbtSQL
{
	template <typename T> struct SQLiteHandlePtrTraits
	{
		using Type = T;
		static Type Invalid() _cmbt_noexcept_ { return nullptr; }
		// any real world SQLiteHandlePtrTraits derived class is supposed to implement the following method
		// static void Close (Type value) _cmbt_noexcept_
	};

	// D:   Basishandle - Muss für Objekte die von der sqlite C API zurückgegeben werden spezialisiert werden 
	// US:  Basic handle - Has to be spezialized for any object returned by sqlite C API
	template <typename Traits> class SQLiteHandle
	{
	private:
		using Type = decltype(Traits::Invalid());
		void Close() _cmbt_noexcept_
		{
			if(*this)
			{
				Traits::Close(_value);
			}
		}
	private:
		Type _value;

	public:
		SQLiteHandle(const SQLiteHandle& cp) = delete;
		SQLiteHandle& operator=(const SQLiteHandle& rhs) = delete;
		explicit SQLiteHandle(Type value = Traits::Invalid()) _cmbt_noexcept_ : _value(value) {}
		SQLiteHandle(SQLiteHandle&& cp) _cmbt_noexcept_ : _value(cp.Detach()) {}


		SQLiteHandle& operator=(const SQLiteHandle&& rhs) _cmbt_noexcept_
		{
			if (this != &rhs)
			{
				Reset(rhs.Detach());
			}
			return *this;
		}
		~SQLiteHandle() _cmbt_noexcept_
		{
			Close();
		}
		explicit operator bool() const _cmbt_noexcept_
		{
			return _value != Traits::Invalid();
		}
		Type Get() const _cmbt_noexcept_ { return _value; }
		Type * Set() _cmbt_noexcept_
		{
			CMBTVERIFY(!*this);
			return &_value;
		}
		Type Detach() _cmbt_noexcept_
		{
			Type value = _value;
			_value = Traits::Invalid();
			return value;
		}
		bool Reset(Type value = Traits::Invalid()) _cmbt_noexcept_
		{
			if (_value != value)
			{
				Close();
				_value = value;
			}
			return static_cast<bool>(*this);
		}
		void swap(SQLiteHandle<Traits>& other) _cmbt_noexcept_
		{
			Type temp = _value;
			_value = other._value;
			other._value = temp;
		}
	};

	template <typename Traits> void swap(SQLiteHandle<Traits>& lhs, SQLiteHandle<Traits>& rhs) _cmbt_noexcept_
	{
		lhs.swap(rhs);
	}

	template <typename Traits> bool operator==(SQLiteHandle<Traits>& lhs, SQLiteHandle<Traits>& rhs) _cmbt_noexcept_
	{
		return lhs.Get() == rhs.Get();
	}

	template <typename Traits> bool operator!=(SQLiteHandle<Traits>& lhs, SQLiteHandle<Traits>& rhs) _cmbt_noexcept_
	{
		return !(lhs == rhs);
	}

}