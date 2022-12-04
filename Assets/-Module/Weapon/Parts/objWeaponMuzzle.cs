using System.Collections.Generic;
using UnityEngine;

public class objWeaponMuzzle : TransformBehaviour
{
	private List<ParticleSystem> Particles = new List<ParticleSystem>();
	private AudioSource m_audioSource = null;

	void Awake()
	{
		m_audioSource = transform.GetComponentInChildren(typeof(AudioSource)) as AudioSource;
		if( m_audioSource!=null )
		{
			m_audioSource.volume = 0.15f;
		}
	}

	//��ƼŬ�� ����ϱ� ���� �Լ�
	public void Register( ParticleSystem particle )
	{
		if( particle==null ) return;

		if( !GetList().Contains(particle) )
		{
			Renderer renderer = particle.GetComponent(typeof(Renderer)) as Renderer;
			if( renderer!=null )
			{
				renderer.material.shader = Shader.Find(renderer.material.shader.name);
			}

			GetList().Add(particle);
		}
	}

	//����Ʈ�� ��� ���� �Լ�
	public List<ParticleSystem> GetList()
	{
		return Particles;
	}

	//����� ������ ����ϱ� ���� �Լ�
	public AudioSource AudioSource()
	{
		return m_audioSource;
	}

	//������ ó���ϱ� ���� �Լ�
	public void Fire()
	{
		foreach( ParticleSystem particle in GetList() )
		{
			particle.Play();
		}

		if( AudioSource()!=null )
		{
			AudioSource().Play();
		}
	}
}